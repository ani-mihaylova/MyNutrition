namespace Nutrition.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Nutrition.Data;
    using Nutrition.Models;
    using Nutrition.Web.ViewModels.Recipes;
    using System.IO;
    using AutoMapper.QueryableExtensions;
    using Nutrition.Web.Infrastructure.Common;


    public class RecipeController : BaseController
    {
        public RecipeController(INutritionData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            var newRecipe = new CreateRecipeViewModel();
            var tagNamesList = new List<SelectListItem>();
            var allTags = this.data.Tags.All();

            foreach (var tag in allTags)
            {
                var newItem = new SelectListItem()
                {
                    Text = tag.Name,
                    Value = tag.ID.ToString()
                };

                tagNamesList.Add(newItem);
            }

            newRecipe.Tags = tagNamesList;

            return this.View("Create", newRecipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var newRecipe = Mapper.Map<Recipe>(model);

            if (model.UploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    newRecipe.Image = new Image
                    {
                        Content = content,
                        FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last()
                    };
                }
            }

            foreach (var tagId in model.TagIds)
            {
                var currentTag = this.data.Tags.GetById(tagId);
                newRecipe.Tags.Add(currentTag);
            }

            var currentUser = this.GetCurrentUser();
            currentUser.MyRecipes.Add(newRecipe);

            this.data.SaveChanges();

            return this.Redirect("/");
        }

        [HttpGet]
        public ActionResult UserRecipesDetails()
        {
            //var currentUser = this.GetCurrentUser();
            //var ids = currentUser.MyRecipes.Select(r => r.ID);
            //var userId = this.User.Identity.GetUserId();

            //var userRecipes = this.data.Users.All()
            //    .Where(u => u.Id == userId)
            //    .SelectMany(u => u.MyRecipes)
            //    .Include("Image")
            //    .Project()
            //    .To<UserRecipesViewModel>()
            //    .ToList();

            //var userRecipes = this.data.Users
            //    .All()
            //    .Include("MyRecipes")
            //    .FirstOrDefault(u => u.Id == userId)
            //    .MyRecipes
            //    .AsQueryable()
            //    .Project()
            //    .To<UserRecipesViewModel>()
            //    .ToList();

            var currentUser = this.GetCurrentUser();
            var userRecipes = currentUser.MyRecipes.AsQueryable()
                .Project()
                .To<UserRecipesViewModel>()
                .ToList();

            return this.View("UserRecipesDetails", userRecipes);
        }

        public ActionResult Image(int id)
        {
            var image = this.data.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }

        [HttpGet]
        public ActionResult Details(int recipeId)
        {
            var recipe = this.data.Recipes
                .All()
                .Where(r => r.ID == recipeId)
                .Project()
                .To<DetailsRecipeViewModel>()
                .FirstOrDefault();

            return this.View("Details", recipe);
        }

        [HttpGet]
        public ActionResult Search(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return this.Redirect("/");
            }

            var matchTags = this.data.Tags
                .All()
                .Where(t => t.Name.Contains(input));


            var matchRecipes = this.data.Recipes.All()
                .Where(r => (r.Tags.Intersect(matchTags).Count()) != 0)
                .Project()
                .To<SearchResultRecipeViewModel>()
                .ToList();

            return this.View("SearchResults", matchRecipes);
        }

        [HttpGet]
        public ActionResult PickRecipe(string fromAll)
        {
            DetailsRecipeViewModel randomRecipe = null;

            if (fromAll != null)
            {
                var allRecipes = this.data.Recipes
                    .All();
                randomRecipe = this.GetRandomRecipe(allRecipes);
            }
            else
            {
                var currentUser = this.GetCurrentUser();
                randomRecipe = this.GetRandomRecipe(currentUser.MyRecipes.AsQueryable());
            }

            return this.View("Details", randomRecipe);
        }

        private DetailsRecipeViewModel GetRandomRecipe(IQueryable<Recipe> recipes)
        {
            var randomNum = RandomGenerator.GenerateRandomNumber(0, recipes.Count());

            var randomRecipe = recipes
                .Project()
                .To<DetailsRecipeViewModel>()
                .ToList()[randomNum];

            return randomRecipe;
        }
    }
}
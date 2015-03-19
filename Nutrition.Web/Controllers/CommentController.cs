namespace Nutrition.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Data;
    using AutoMapper.QueryableExtensions;
    using Nutrition.Web.ViewModels.Comments;
    using AutoMapper;
    using Nutrition.Models;

    public class CommentController : BaseController
    {
        public CommentController(INutritionData data)
            : base(data)
        {

        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ListComments(int recipeId)
        {
            var recipeComments = this.data.Recipes
                .GetById(recipeId)
                .Comments
                .AsQueryable()
                .Project()
                .To<CommentDetailsViewModel>()
                .ToList();

            return this.View("ListComments", recipeComments);

        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Create(int recipeId)
        {
            var newComment = new CreateCommentViewModel();
            var currentUser = this.GetCurrentUser();
            newComment.UserId = currentUser.Id;
            newComment.RecipeId = recipeId;

            return this.View("Create", newComment);
        }

        [HttpPost]
        [ChildActionOnly]
        public ActionResult Create(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.Redirect("/Recipe/Details?recipeId=" + model.RecipeId);
            }
            var newComment = Mapper.Map<Comment>(model);

            newComment.User = this.data.Users.GetById(model.UserId);
            var currentRecipe = this.data.Recipes.GetById(model.RecipeId);
            currentRecipe.Comments.Add(newComment);

            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

            return this.Redirect("/Recipe/Details?recipeId=" + model.RecipeId);
        }
    }
}
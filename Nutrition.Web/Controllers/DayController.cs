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
    using Nutrition.Web.ViewModels.Days;


    public class DayController : BaseController
    {
        public DayController(INutritionData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult CreateDays(int dietId, int numberOfDays)
        {
            var newDays = new List<CreateDayViewModel>();
            var currentUserRecipes = this.GetCurrentUser().MyRecipes;
            var userRecipes = new List<SelectListItem>();

            foreach (var recipe in currentUserRecipes)
            {
                userRecipes.Add(new SelectListItem()
                    {
                        Text = recipe.Title,
                        Value = recipe.ID.ToString()
                    });
            }


            for (int i = 0; i < numberOfDays; i++)
            {
                newDays.Add(new CreateDayViewModel()
                    {
                        DietId = dietId,
                        Number = i + 1,
                        UserRecipes = userRecipes
                    });
            }

            return this.View("CreateDays", newDays);
        }

        [HttpPost]
        public void Create(CreateDayViewModel model)
        {
            var isAjax = Request.IsAjaxRequest();
            var diet = this.data.Diets.GetById(model.DietId);
            var newDay = Mapper.Map<Day>(model);

            var selectedRecipes = this.data.Recipes
                .All()
                .Where(r => model.RecipeIds.Contains(r.ID))
                .ToList();
            newDay.Recipes = selectedRecipes;
            diet.Days.Add(newDay);

            this.data.SaveChanges();
        }

        [HttpGet]
        public ActionResult DayDetails(int dayId)
        {

            return this.View("DayDetails");
        }

    }
}
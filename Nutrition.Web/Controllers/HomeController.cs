using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nutrition.Data;
using AutoMapper.QueryableExtensions;
using Nutrition.Web.ViewModels.Homes;

namespace Nutrition.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INutritionData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            var topRecipes = this.data.Recipes
                .All()
                .OrderBy(r => r.Rating.Value)                
                .Project()
                .To<HomePageRecipeViewModel>()
                .Take(10)
                .ToList();

            return View("Index",topRecipes);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult UserTopRecipes()
        {
            var currentUser = this.GetCurrentUser();
            var topRecipesByUser = currentUser.MyRecipes
                .AsQueryable()
                .OrderBy(r => r.Rating)
                .Project()
                .To<HomePageRecipeViewModel>()
                .Take(10)
                .ToList();

            return this.PartialView("_TopRecipesByUser", topRecipesByUser);
        }
    }
}
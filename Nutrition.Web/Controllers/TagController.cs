namespace Nutrition.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Data;
    using AutoMapper.QueryableExtensions;
    using Nutrition.Web.ViewModels.Recipes;
    using System.Data.Entity;

    public class TagController : BaseController
    {
        public TagController(INutritionData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult ShowRecipesByTag(string tagName)
        {
            var allRecipesByTag = this.data.Recipes
                .All()
                .Include("Tags")
                .Where(r => r.Tags.Select(t=>t.Name).Contains(tagName))
                .Project()
                .To<RecipeByTagViewModel>()
                .ToList();

            this.ViewData.Add("tagName", tagName);

            return this.View("ShowRecipesByTag", allRecipesByTag);
        }


    }
}
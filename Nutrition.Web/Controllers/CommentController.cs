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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
namespace Nutrition.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Nutrition.Data;
    using Nutrition.Models;
    using Nutrition.Web.ViewModels.Days;
    using Nutrition.Web.ViewModels.Diets;
    using System.Data.Entity;

    public class DietController : BaseController
    {
        public DietController(INutritionData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult Create()
        {
            var newDiet = new CreateDietViewModel();

            return this.View("Create", newDiet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CreateDietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var newDiet = Mapper.Map<Diet>(model);
            var currentUser = this.GetCurrentUser();
            currentUser.Diets.Add(newDiet);

            this.data.Diets.Add(newDiet);
            this.data.SaveChanges();

            return this.Redirect("/Day/CreateDays?dietId=" + newDiet.ID + "&numberOfDays=" + newDiet.NumberOfDays);
        }

        [HttpGet]
        public ActionResult Details()
        {
            var currentUserDiets = this.GetCurrentUser()
                .Diets;

            return this.View("Details", currentUserDiets);
        }
    }
}
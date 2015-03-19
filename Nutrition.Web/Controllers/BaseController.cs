namespace Nutrition.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Data;
    using Nutrition.Models;
    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        protected INutritionData data;

        public BaseController(INutritionData data)
        {
            this.data = data;
        }

        protected User GetCurrentUser()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data.Users.GetById(currentUserId);

            return currentUser;
        }
    }
}
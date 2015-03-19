using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nutrition.Data;

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
            return View();
        }
    }
}
namespace Nutrition.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Data;

    public class UserController : BaseController
    {
        public UserController(INutritionData data)
            : base(data)
        {

        }

        
    }
}
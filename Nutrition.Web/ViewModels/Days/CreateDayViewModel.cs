namespace Nutrition.Web.ViewModels.Days
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class CreateDayViewModel : IMapFrom<Day>
    {
        [HiddenInput(DisplayValue=false)]
        public int DietId { get; set; }

        [Required]
        public ICollection<Recipe> Recipes { get; set; }

        [Required]
        public int Number { get; set; }

        [UIHint("Multiline")]
        public string Description { get; set; }

        [UIHint("MultiSelect")]
        public ICollection<SelectListItem> UserRecipes { get; set; }

        public IEnumerable<int> RecipeIds { get; set; }
    }
}
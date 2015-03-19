namespace Nutrition.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class CreateRecipeViewModel : IMapFrom<Recipe>
    {
        [Required]
        [UIHint("String")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Multiline")]
        public string Description { get; set; }

        [UIHint("DateTime")]
        public DateTime? TimeToEat { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Multiline")]
        public string Ingredients { get; set; }

        [UIHint("MultiSelect")]
        public ICollection<SelectListItem> Tags { get; set; }

        public IEnumerable<int> TagIds { get; set; }

        [UIHint("Image")]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
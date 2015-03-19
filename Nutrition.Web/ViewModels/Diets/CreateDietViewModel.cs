namespace Nutrition.Web.ViewModels.Diets
{
    using System.ComponentModel.DataAnnotations;
    using Nutrition.Web.Infrastructure.Mapping;
    using Model = Nutrition.Models.Diet;

    public class CreateDietViewModel:IMapFrom<Model>
    {
        [Required]
        [UIHint("String")]
        public string Name { get; set; }

        [Required]
        [UIHint("Number")]
        public int? NumberOfDays { get; set; }
    }
}
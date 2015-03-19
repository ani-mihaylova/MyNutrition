namespace Nutrition.Web.ViewModels.Recipes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class DetailsRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public string Ingredients { get; set; }

        public virtual ICollection<string> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, DetailsRecipeViewModel>()
                .ForMember(m => m.Tags, opt => opt.MapFrom(t => t.Tags.Select(r => r.Name)))
                .ForMember(m => m.ImageId, opt => opt.MapFrom(t => t.Image.ID))
                .ReverseMap();
        }
    }
}
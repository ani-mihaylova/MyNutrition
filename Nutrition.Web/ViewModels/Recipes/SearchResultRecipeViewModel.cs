namespace Nutrition.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class SearchResultRecipeViewModel:IMapFrom<Recipe>,IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public ICollection<string> TagNames { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, SearchResultRecipeViewModel>()
                .ForMember(r => r.TagNames, opt => opt.MapFrom(t => t.Tags.Select(k => k.Name)))
                .ForMember(r=>r.ImageId,opt=>opt.MapFrom(t=>t.Image.ID))
                .ReverseMap();
        }
    }
}
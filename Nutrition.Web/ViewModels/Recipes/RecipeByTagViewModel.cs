using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Nutrition.Models;
using Nutrition.Web.Infrastructure.Mapping;

namespace Nutrition.Web.ViewModels.Recipes
{
    public class RecipeByTagViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int? ImageId { get; set; }

        //public virtual Rating Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, RecipeByTagViewModel>()
                .ForMember(t => t.ImageId, opt => opt.MapFrom(r => r.Image.ID))
                .ReverseMap();
        }
    }
}
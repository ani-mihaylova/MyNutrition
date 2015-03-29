using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Nutrition.Models;
using Nutrition.Web.Infrastructure.Mapping;

namespace Nutrition.Web.ViewModels.Homes
{
    public class HomePageRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public int? ImageId { get; set; }

        public int? Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, HomePageRecipeViewModel>()
                .ForMember(t => t.Rating, opt => opt.MapFrom(r => r.Rating.Value))
                .ReverseMap();
        }
    }
}
namespace Nutrition.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class UserRecipesViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        public string Title { get; set; }

        public int? ImageId { get; set; }
        //public Image Image { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, UserRecipesViewModel>()
                .ForMember(m => m.ImageId, opt => opt.MapFrom(t => t.Image.ID))
                .ReverseMap();
        }
    }
}
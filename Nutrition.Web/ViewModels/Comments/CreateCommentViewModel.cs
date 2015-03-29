namespace Nutrition.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Nutrition.Models;
    using Nutrition.Web.Infrastructure.Mapping;

    public class CreateCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [Required]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        public string UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CreateCommentViewModel>()
                .ForMember(t => t.UserId, opt => opt.MapFrom(u => u.ID));
        }
    }
}
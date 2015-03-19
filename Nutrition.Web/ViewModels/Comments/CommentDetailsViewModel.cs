using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Nutrition.Models;
using Nutrition.Web.Infrastructure.Mapping;

namespace Nutrition.Web.ViewModels.Comments
{
    public class CommentDetailsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string Username { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentDetailsViewModel>()
                .ForMember(t => t.Username, opt => opt.MapFrom(u => u.User.UserName))
                .ReverseMap();
        }
    }
}
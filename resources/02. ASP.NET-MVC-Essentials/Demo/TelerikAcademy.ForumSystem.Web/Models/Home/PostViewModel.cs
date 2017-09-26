using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Web.Infrastructure;

namespace TelerikAcademy.ForumSystem.Web.Models.Home
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [Display(Name = "Pesho's super awesome name field")]
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postViewModel => postViewModel.AuthorEmail, cfg => cfg.MapFrom(post => post.Author.Email))
                .ForMember(postViewModel => postViewModel.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn));
        }
    }
}
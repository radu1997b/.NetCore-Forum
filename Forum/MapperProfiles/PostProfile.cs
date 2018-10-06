using AutoMapper;
using Forum.BLL.DataTransferObjects.Post;
using Forum.DAL.Domain;
using Forum.Web.Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.MapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>().ForMember(p => p.AuthorFullName,
                                     o => o.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                          .ForMember(p => p.AuthorEmail,
                                     o => o.MapFrom(src => src.Author.Email))
                          .ForMember(p => p.AuthorNumberOfPosts,
                                     o => o.MapFrom(src => src.Author.Posts.Count()))
                          .ForMember(p => p.UserPhotoPath, o => o.MapFrom(src => src.Author.UserPhotoPath));
            CreateMap<CreatePostViewModel, CreatePostDTO>();
            CreateMap<CreatePostDTO, Post>();
        }
    }
}

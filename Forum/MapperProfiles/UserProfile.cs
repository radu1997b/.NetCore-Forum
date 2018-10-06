using AutoMapper;
using Forum.DAL.Domain;
using Forum.Web.Models.ProfileViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UpdateProfileViewModel>().ReverseMap().ForMember(p => p.UserPhotoPath, opt => opt.Ignore());
            CreateMap<User, ProfileViewModel>().ForMember(p => p.FullName, o => o.MapFrom(src => src.FirstName + " " + src.LastName))
                                               .ForMember(p => p.NumberOfPosts, o => o.MapFrom(src => src.Posts.Count()));
        }
    }
}

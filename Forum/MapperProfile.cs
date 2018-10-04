using AutoMapper;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.DAL.Domain;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.ProfileViewModels;
using Forum.Web.Models.RoomViewModels;
using Forum.Web.Models.TopicViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UpdateProfileViewModel>().ReverseMap();
            CreateMap<Topic, TopicDTO>().ForMember(dest => dest.NumberOfRooms,
                                                   opt => opt.MapFrom(src => src.Rooms.Count()));
            CreateMap<TopicDTO, Topic>();
            CreateMap<TopicDTO, TopicViewModel>();
            CreateMap<TopicUpdateViewModel, TopicDTO>();
            CreateMap<TopicCreateViewModel, TopicDTO>();
            CreateMap<Post, PostDTO>().ForMember(p => p.AuthorFullName,
                                                 o => o.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                                      .ForMember(p => p.AuthorEmail,
                                                 o => o.MapFrom(src => src.Author.Email))
                                      .ForMember(p => p.AuthorNumberOfPosts,
                                                 o => o.MapFrom(src => src.Author.Posts.Count()))
                                      .ForMember(p => p.UserPhotoPath, o => o.MapFrom(src => src.Author.UserPhotoPath));
            CreateMap<Room, RoomDTO>().ForMember(p => p.TopicName,
                                                 o => o.MapFrom(src => src.Topic.TopicName))
                                      .ForMember(p => p.NumberOfPosts,
                                                 o => o.MapFrom(src => src.Posts.Count()))
                                      .ForMember(p => p.RoomId,
                                                 o => o.MapFrom(src => src.Id));
                                      
            CreateMap<RoomDTO, RoomViewModel>();
            CreateMap<CreatePostViewModel, CreatePostDTO>();
            CreateMap<CreatePostDTO, Post>();
            CreateMap<SubscriptionsDTO, UserRoom>();
            CreateMap<CreateRoomViewModel, CreateRoomDTO>().ReverseMap();
            CreateMap<CreateRoomDTO, Room>().ReverseMap();
            CreateMap<Topic, TopicListItemDTO>();
            CreateMap<TopicListItemDTO, SelectListItem>().ForMember(p => p.Value, o => o.MapFrom(src => src.Id.ToString()))
                                                        .ForMember(p => p.Text, o => o.MapFrom(src => src.TopicName));
            CreateMap<Topic, TopicInfoDTO>();
            CreateMap<TopicInfoDTO, TopicInfoViewModel>();
            CreateMap<User, ProfileViewModel>().ForMember(p => p.FullName, o => o.MapFrom(src => src.FirstName + src.LastName));
        }
    }
}

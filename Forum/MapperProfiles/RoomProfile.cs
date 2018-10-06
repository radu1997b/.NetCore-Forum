using AutoMapper;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.DAL.Domain;
using Forum.Web.Models.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.MapperProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>().ForMember(p => p.TopicName,
                                     o => o.MapFrom(src => src.Topic.TopicName))
                          .ForMember(p => p.NumberOfPosts,
                                     o => o.MapFrom(src => src.Posts.Count()))
                          .ForMember(p => p.RoomId,
                                     o => o.MapFrom(src => src.Id));
            CreateMap<RoomDTO, RoomViewModel>();
            CreateMap<CreateRoomViewModel, CreateRoomDTO>().ReverseMap();
            CreateMap<CreateRoomDTO, Room>().ReverseMap();
            CreateMap<RoomDTO, RoomPartialViewModel>();
            CreateMap<SubscriptionsDTO, UserRoom>();
        }
    }
}

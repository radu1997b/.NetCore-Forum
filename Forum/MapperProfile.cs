using AutoMapper;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.DAL.Domain;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Forum.Web.Models.ProfileViewModels;
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
                                                   opt => opt.MapFrom(src => src.Rooms.Count())).ReverseMap();
            CreateMap<TopicDTO, TopicViewModel>();
            CreateMap<TopicUpdateViewModel, TopicDTO>().ForMember(dest => dest.TopicCreationDate,
                                                                 opt => opt.Ignore());
        }
    }
}

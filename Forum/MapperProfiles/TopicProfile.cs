using AutoMapper;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.DAL.Domain;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Forum.Web.Models.TopicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.MapperProfiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDTO>().ForMember(dest => dest.NumberOfRooms,
                                                   opt => opt.MapFrom(src => src.Rooms.Count()));
            CreateMap<TopicDTO, Topic>().ForMember(p => p.CreationDate, opt => opt.Ignore());
            CreateMap<TopicDTO, TopicViewModel>();
            CreateMap<TopicUpdateViewModel, TopicDTO>();
            CreateMap<TopicCreateViewModel, TopicDTO>();
            CreateMap<Topic, TopicListItemDTO>();
            CreateMap<Topic, TopicInfoDTO>();
            CreateMap<TopicInfoDTO, TopicInfoViewModel>();
        }
    }
}

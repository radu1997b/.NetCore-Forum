using AutoMapper;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        public RoomService(IRoomRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public RoomDTO GetRoomDetails(long Id)
        {
            var Room = _repository.GetById(Id);
            var result = _mapper.Map<Room, RoomDTO>(Room);
            return result;
        }
        public void CreateRoom(CreateRoomDTO roomDTO)
        {
            var roomDomain = _mapper.Map<CreateRoomDTO, Room>(roomDTO);
            _repository.Add(roomDomain);
            _repository.Save();
        }

        public PagedResult<RoomDTO> GetRoomsByTopic(long TopicId,PagedRequestDescription pagedRequestDescription)
        {
            var getRoomsDomain = _repository.GetRoomsByTopicPaginated(TopicId, pagedRequestDescription);
            var result = new PagedResult<RoomDTO>
            {
                AllItemsCount = getRoomsDomain.AllItemsCount,
                result = _mapper.Map<IList<Room>, IList<RoomDTO>>(getRoomsDomain.result)
            };
            return result;
        }
    }
}

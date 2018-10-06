using AutoMapper;
using Cross_cutting.Interfaces;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services
{
    public class RoomService : IRoomService,IScopedService
    {
        private IRoomRepository _repository;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        public RoomService(IRoomRepository repository,IMapper mapper,UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
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
        public PagedResult<RoomDTO> GetRoomsPaginated(PagedRequestDescription pagedRequestDescription)
        {
            var queryResult = _repository.GetRoomsPaginated(pagedRequestDescription);
            var pagedResult = new PagedResult<RoomDTO>
            {
                AllItemsCount = queryResult.AllItemsCount,
                result = _mapper.Map<IList<Room>, IList<RoomDTO>>(queryResult.result)
            };
            return pagedResult;
        }
        public IList<RoomDTO> GetLatestRooms()
        {
            var queryResult = _repository.GetLatestRooms(10);
            var listDto = _mapper.Map<IList<Room>,IList<RoomDTO>> (queryResult);
            return listDto;
        }

        public IList<RoomDTO> GetFavoriteRooms(string UserId)
        {
            var user = _userManager.FindByIdAsync(UserId).Result;
            if (user == null)
                throw new ArgumentNullException();
            var queryResult = _repository.GetFavoriteRooms(UserId,10);
            var listDto = _mapper.Map<IList<Room>, IList<RoomDTO>>(queryResult);
            return listDto;
        }

        public IList<RoomDTO> GetPopularRooms()
        {
            var queryResult = _repository.GetPopularRooms(10);
            var listDto = _mapper.Map<IList<Room>, IList<RoomDTO>>(queryResult);
            return listDto;
        }
    }
}

using AutoMapper;
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
        private IRepository<Room> _repository;
        private IMapper _mapper;
        public RoomService(IRepository<Room> repository,IMapper mapper)
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
    }
}

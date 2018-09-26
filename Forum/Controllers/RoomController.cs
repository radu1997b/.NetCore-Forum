using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Cross_cutting.ExceptionHandlingFilter;
using Cross_cutting.Exceptions;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.Interfaces;
using Forum.Web.Models.RoomViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private IMapper _mapper;
        public RoomController(IRoomService roomServices,IMapper mapper)
        {
            _roomService = roomServices;
            _mapper = mapper;
        }
        public IActionResult GetRoom(long Id)
        {
            var roomDetails = _roomService.GetRoomDetails(Id);
            var result = _mapper.Map<RoomDTO, RoomViewModel>(roomDetails);
            return View(result);
        }
    }
}
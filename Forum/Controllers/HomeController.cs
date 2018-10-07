using System.Collections.Generic;
using AutoMapper;
using Cross_cutting.Extensions;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.Interfaces;
using Forum.Web.Models.HomeViewModels;
using Forum.Web.Models.RoomViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IRoomService _roomService;
        private IMapper _mapper;
        public HomeController(IRoomService roomService,IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            var latestRooms = _roomService.GetLatestRooms();
            model.LatestRooms = _mapper.Map<IList<RoomDTO>, IList<RoomPartialViewModel>>(latestRooms);
            var favoriteRooms = _roomService.GetFavoriteRooms(User.GetUserId());
            model.FavoriteRooms = _mapper.Map<IList<RoomDTO>, IList<RoomPartialViewModel>>(favoriteRooms);
            var popularRooms = _roomService.GetPopularRooms();
            model.PopularRooms = _mapper.Map<IList<RoomDTO>, IList<RoomPartialViewModel>>(popularRooms);
            return View(model);
        }
    }
}

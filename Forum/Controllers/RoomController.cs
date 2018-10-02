using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Cross_cutting.ExceptionHandlingFilter;
using Cross_cutting.Exceptions;
using Cross_cutting.Extensions;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.BLL.Interfaces;
using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.RoomViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private ISubscriptionService _subscriptionService;
        private IMapper _mapper;
        private IPostService _postService;
        public RoomController(IRoomService roomServices,ISubscriptionService subscriptionService,IMapper mapper,IPostService postService)
        {
            _roomService = roomServices;
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _postService = postService;
        }
        public IActionResult GetRoom(long Id,int page = 1)
        {
            var roomDetails = _roomService.GetRoomDetails(Id);
            var result = _mapper.Map<RoomDTO, RoomViewModel>(roomDetails);
            var userId = HttpContext.User.GetUserId();
            result.IsSubscribed = _subscriptionService.GetSubscriptionStatusForUser(userId,Id);
            var getPostsPaginated = _postService.GetPostsPaginated(p => p.RoomId == Id, page);
            result.PostList = _mapper.Map<IList<PostDTO>, IList<PostViewModel>>(getPostsPaginated.result);
            return View(result);
        }
    }
}
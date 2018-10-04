using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Cross_cutting.ExceptionHandlingFilter;
using Cross_cutting.Exceptions;
using Cross_cutting.Extensions;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Interfaces;
using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.RoomViewModels;
using Forum.Web.Models.TopicViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.Web.Controllers
{
    public class RoomController : BaseController
    {
        private IRoomService _roomService;
        private ISubscriptionService _subscriptionService;
        private IMapper _mapper;
        private IPostService _postService;
        private ITopicService _topicService;
        public RoomController(IRoomService roomServices,
            ISubscriptionService subscriptionService,
            IMapper mapper,IPostService postService,
            ITopicService topicService)
        {
            _roomService = roomServices;
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _postService = postService;
            _topicService = topicService;
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
        [HttpGet]
        public IActionResult CreateRoom()
        {
            var allTopics = _topicService.GetAllTopics();
            var model = new CreateRoomViewModel
            {
                ListOfTopics = _mapper.Map<IEnumerable<TopicListItemDTO>, IEnumerable<SelectListItem>>(allTopics)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(CreateRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddErrors("Error on creating room!");
                return RedirectToAction(nameof(RoomController.CreateRoom));
            }
            var roomDto = _mapper.Map<CreateRoomViewModel, CreateRoomDTO>(model);
            _roomService.CreateRoom(roomDto);
            return RedirectToHomePage();
        }
        [HttpGet]
        public IActionResult RoomsByTopic(long Id)
        {
            var topicInfoDto = _topicService.GetTopicInfo(Id);
            var model = _mapper.Map<TopicInfoDTO, TopicInfoViewModel>(topicInfoDto);
            return View(model);
        }
        [HttpGet]
        public IActionResult GetRoomsByTopic(long TopicId,PagedRequestDescription pagedRequestDescription)
        {
            var roomsPaginated = _roomService.GetRoomsByTopic(TopicId, pagedRequestDescription);
            var result = new
            {
                recordsTotal = roomsPaginated.AllItemsCount,
                recordsFiltered = roomsPaginated.AllItemsCount,
                data = roomsPaginated.result
            };
            return Json(result);
        }
    }
}
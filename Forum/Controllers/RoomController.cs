using System.Collections.Generic;
using AutoMapper;
using Cross_cutting.Extensions;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.DataTransferObjects.Room;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Interfaces;
using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.RoomViewModels;
using Forum.Web.Models.TopicViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
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
            var getPostsPaginated = _postService.GetPostsPaginated(Id, page);
            result.NumberOfPages = getPostsPaginated.NumberOfPages;
            result.PostList = _mapper.Map<IList<PostDTO>, IList<PostViewModel>>(getPostsPaginated.result);
            result.CurrentPage = page;
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {
            var allTopics = _topicService.GetAllTopics();
            var model = new CreateRoomViewModel
            {
                ListOfTopics = allTopics.ToSelectList(0, false, x => x.Id, x => x.TopicName)
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
                return View();
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
        //Used by datatable
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
        [HttpGet]
        public IActionResult AllRooms()
        {
            return View();
        }
        //Used by datatable
        [HttpGet]
        public IActionResult AllRoomsJson(PagedRequestDescription pagedRequestDescription)
        {
            var roomsPaginated = _roomService.GetRoomsPaginated(pagedRequestDescription);
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
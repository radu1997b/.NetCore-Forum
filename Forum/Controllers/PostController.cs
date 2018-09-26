using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Cross_cutting.Extensions;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.Interfaces;
using Forum.Web.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;
        private IUserService _userService;
        private IMapper _mapper;
        public PostController(IPostService postService,IUserService userService,IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult GetPostsByRoom(long RoomID,PagedRequestDescription pagedRequestDescription)
        {
            var getPostsFiltered = _postService.GetPostsPaginated(p => p.RoomId == RoomID, pagedRequestDescription);
            var result = new
            {
                recordsTotal = getPostsFiltered.AllItemsCount,
                recordsFiltered = getPostsFiltered.AllItemsCount,
                data = _mapper.Map<ICollection<PostDTO>, ICollection<PostViewModel>>(getPostsFiltered.result)
            };
            return Json(result);
        }
        public IActionResult GetPostsByUser(string AuthorId,PagedRequestDescription pagedRequestDescription)
        {
            var getPostsFiltered = _postService.GetPostsPaginated(p => p.AuthorId == AuthorId, pagedRequestDescription);
            var result = new
            {
                recordsTotal = getPostsFiltered.AllItemsCount,
                recordsFiltered = getPostsFiltered.AllItemsCount,
                data = _mapper.Map<ICollection<PostDTO>, ICollection<PostViewModel>>(getPostsFiltered.result)
            };
            return Json(result);
        }
        [HttpGet]
        public IActionResult GetPost(PostViewModel model)
        {
            return PartialView("_PostPartial",model);
        }
        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unnable to post message.Please try again later.");
                return RedirectToAction("GetRoom", "Room", new { Id = model.RoomId });
            }
            var postDTO = _mapper.Map<CreatePostViewModel, CreatePostDTO>(model);
            postDTO.AuthorId = HttpContext.User.GetUserId();
            _postService.AddPost(postDTO);
            return RedirectToAction("GetRoom", "Room", new { Id = model.RoomId },null);
        }
    }
}
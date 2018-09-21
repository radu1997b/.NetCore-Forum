using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;
        public PostController(IPostService postService,IMapper mapper)
        {
            _postService = postService;
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
    }
}
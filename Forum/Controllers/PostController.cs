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
        private IMapper _mapper;
        public PostController(IPostService postService,IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var postDTO = _mapper.Map<CreatePostViewModel, CreatePostDTO>(model);
            postDTO.AuthorId = HttpContext.User.GetUserId();
            _postService.AddPost(postDTO);
            return Ok();
        }
    }
}
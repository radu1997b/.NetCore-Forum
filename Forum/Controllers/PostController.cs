using AutoMapper;
using Cross_cutting.Extensions;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.Interfaces;
using Forum.Web.Models.PostViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class PostController : BaseController
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
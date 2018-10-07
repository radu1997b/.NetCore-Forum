using AutoMapper;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Forum.BLL.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _repository;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        public PostService(IPostRepository repository,IMapper mapper,UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public PagedResult<PostDTO> GetPostsPaginated(long RoomId,
                                                      int page)
        {
           var postsFiltered = _repository.GetPostsPaginated(RoomId, page);
            var result = new PagedResult<PostDTO>
            {
                AllItemsCount = postsFiltered.AllItemsCount,
                result = _mapper.Map<IList<Post>, IList<PostDTO>>(postsFiltered.result)
            };
            return result;
        }
        public void AddPost(CreatePostDTO post)
        {
            var newPost = _mapper.Map<CreatePostDTO, Post>(post);
            _repository.Add(newPost);
            _repository.Save();
        }
    }
}

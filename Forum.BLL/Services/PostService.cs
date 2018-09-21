using AutoMapper;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Forum.BLL.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _repository;
        private IMapper _mapper;
        public PostService(IPostRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public PagedResult<PostDTO> GetPostsPaginated(Expression<Func<Post, bool>> filter, 
                                                      PagedRequestDescription pagedRequestDescription)
        {
           var postsFiltered = _repository.GetPostsPaginated(filter, pagedRequestDescription);
            var result = new PagedResult<PostDTO>
            {
                AllItemsCount = postsFiltered.AllItemsCount,
                result = _mapper.Map<ICollection<Post>, ICollection<PostDTO>>(postsFiltered.result)
            };
            return result;
        }
    }
}

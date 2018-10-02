using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Forum.DAL.Extensions;

namespace Forum.DAL.Repository
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        { }


        //TODO - REturn PagedResult with DTO
        public PagedResult<Post> GetPostsPaginated(Expression<Func<Post, bool>> filter, 
                                                   int page)
        {
            var result = new PagedResult<Post>
            {
                result = _context.Set<Post>().Where(filter)
                                .Skip((page-1) * 10).Take(10).ToList(),
                AllItemsCount = _context.Set<Post>().Where(filter)
                                        .Count()
            };
            return result;
        }
    }
}

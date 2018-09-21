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
        public PagedResult<Post> GetPostsPaginated(Expression<Func<Post, bool>> filter, 
                                                   PagedRequestDescription pagedRequestDescription)
        {
            return _context.Set<Post>().Where(filter)
                                .Page(pagedRequestDescription);
        }
    }
}

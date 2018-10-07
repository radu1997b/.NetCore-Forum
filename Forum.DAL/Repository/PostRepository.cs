using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Cross_cutting.Extensions;

namespace Forum.DAL.Repository
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        { }
        public PagedResult<Post> GetPostsPaginated(long RoomId, 
                                                   int page)
        {
            var result = _context.Set<Post>().Where(p => p.RoomId == RoomId).Page(page, 10);
            return result;
        }
    }
}

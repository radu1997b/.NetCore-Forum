using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Forum.DAL.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        PagedResult<Post> GetPostsPaginated(Expression<Func<Post, bool>> filter,
                                            PagedRequestDescription pagedRequestDescription);
    }
}

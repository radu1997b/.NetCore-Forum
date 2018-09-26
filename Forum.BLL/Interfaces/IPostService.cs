using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface IPostService
    {
        PagedResult<PostDTO> GetPostsPaginated(Expression<Func<Post,bool>> filter,
                                               PagedRequestDescription pagedRequestDescription);
        void AddPost(CreatePostDTO post);
    }
}

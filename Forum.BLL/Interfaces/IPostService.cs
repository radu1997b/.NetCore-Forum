using Cross_cutting.Interfaces;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;
using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface IPostService : IScopedService
    {
        PagedResult<PostDTO> GetPostsPaginated(long RoomId,
                                               int page);
        void AddPost(CreatePostDTO post);
    }
}

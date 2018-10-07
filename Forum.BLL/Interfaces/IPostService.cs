using Cross_cutting.Interfaces;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Post;

namespace Forum.BLL.Interfaces
{
    public interface IPostService : IScopedService
    {
        PagedResult<PostDTO> GetPostsPaginated(long RoomId,
                                               int page);
        void AddPost(CreatePostDTO post);
    }
}

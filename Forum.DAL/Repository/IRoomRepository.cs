using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DAL.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        PagedResult<Room> GetRoomsByTopicPaginated(long TopicId, PagedRequestDescription pagedRequestDescription);
        PagedResult<Room> GetRoomsPaginated(PagedRequestDescription pagedRequestDescription);
        IList<Room> GetLatestRooms(int numberOfRooms);
        IList<Room> GetPopularRooms(int numberOfRooms);
        IList<Room> GetFavoriteRooms(string UserId,int numberOfRooms);
    }
}

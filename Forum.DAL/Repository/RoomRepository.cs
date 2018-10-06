using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using Forum.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.DAL.Repository
{
    public class RoomRepository : Repository<Room>,IRoomRepository
    {
        public RoomRepository(DbContext context) : base(context)
        { }

        public IList<Room> GetFavoriteRooms(string UserId,int numberOfRooms)
        {
            return _context.Set<UserRoom>().Where(p => p.UserId == UserId).Select(src => src.Room)
                                           .Page(1,numberOfRooms).result;
        }

        public IList<Room> GetLatestRooms(int numberOfRooms)
        {
            return _context.Set<Room>().OrderByDescending(p => p.CreationDate).Page(1,numberOfRooms).result;
        }

        public IList<Room> GetPopularRooms(int numberOfRooms)
        {
            return _context.Set<Room>().OrderByDescending(p => p.Posts.Count()).Page(1, numberOfRooms).result;
        }

        public PagedResult<Room> GetRoomsByTopicPaginated(long TopicId,PagedRequestDescription pagedRequestDescription)
        {
            var queryResult = _context.Set<Room>().Where(p => p.TopicId == TopicId)
                                                  .Page(pagedRequestDescription);
            return queryResult;
        }

        public PagedResult<Room> GetRoomsPaginated(PagedRequestDescription pagedRequestDescription)
        {
            var queryResult = _context.Set<Room>().Page(pagedRequestDescription);
            return queryResult;
        }
    }
}

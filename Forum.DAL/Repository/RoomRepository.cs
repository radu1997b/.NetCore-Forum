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
        public PagedResult<Room> GetRoomsByTopicPaginated(long TopicId,PagedRequestDescription pagedRequestDescription)
        {
            var queryResult = _context.Set<Room>().Where(p => p.TopicId == TopicId)
                                                  .Page(pagedRequestDescription);
            return queryResult;
        }
    }
}

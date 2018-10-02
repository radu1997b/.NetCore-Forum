using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Cross_cutting.Exceptions;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace Forum.DAL.Repository
{
    public class SubscriptionsRepository : Repository<UserRoom>,ISubscriptionsRepository
    {
        public SubscriptionsRepository(DbContext context) : base(context)
        { }
        public UserRoom GetById(string UserId,long RoomId)
        {
            return _context.Set<UserRoom>().Find(UserId,RoomId);
        }
    }
}
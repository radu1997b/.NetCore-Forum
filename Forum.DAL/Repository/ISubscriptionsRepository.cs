using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DAL.Repository
{
    public interface ISubscriptionsRepository : IRepository<UserRoom>
    {
        UserRoom GetById(string UserId,long RoomId);
    }
}

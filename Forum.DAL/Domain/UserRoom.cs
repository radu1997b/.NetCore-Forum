﻿
namespace Forum.DAL.Domain
{
    public class UserRoom : Entity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public long RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}

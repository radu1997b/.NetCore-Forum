using System;
using System.Collections.Generic;

namespace Forum.DAL.Domain
{
    public class Room : Entity
    {
        public string RoomName { get; set; }
        public virtual Topic Topic { get; set; }
        public long TopicId { get; set; }
        public virtual ICollection<UserRoom> UserRooms { get; set; }
        public virtual ICollection<Post> Posts { get; set; } 
    }
}

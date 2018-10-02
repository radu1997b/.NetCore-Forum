using System;

namespace Forum.DAL.Domain
{
    public class Post : Entity
    {
        public string Message { get; set; }
        public virtual User Author { get; set; }
        public string AuthorId { get; set; }
        public virtual Room Room { get; set; }
        public long RoomId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Forum.DAL.Domain
{
    public class Topic : Entity
    {
        public string TopicName { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}

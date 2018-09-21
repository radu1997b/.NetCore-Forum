using System;
using System.Collections.Generic;

namespace Forum.DAL.Domain
{
    public class Topic : Entity
    {
        public Topic()
        {
            TopicCreationDate = DateTime.Now;
        }
        public string TopicName { get; set; }
        public DateTime TopicCreationDate { get; set; }
        public virtual ICollection<Room> Rooms { get; set; } 
    }
}

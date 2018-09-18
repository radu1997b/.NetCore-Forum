using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Topic
{
    public class TopicDTO
    {
        public long Id { get; set; }
        public string TopicName { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime TopicCreationDate { get; set; }
    }
}

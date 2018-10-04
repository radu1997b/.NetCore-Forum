using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Room
{
    public class RoomDTO
    {
        public long RoomId { get; set; }
        public string TopicName { get; set; }
        public string RoomName { get; set; }
        public int NumberOfPosts { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

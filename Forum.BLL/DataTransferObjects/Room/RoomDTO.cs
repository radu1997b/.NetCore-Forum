using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Room
{
    public class RoomDTO
    {
        public string TopicName { get; set; }
        public string RoomName { get; set; }
        public int NumberOfPosts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Room
{
    public class CreateRoomDTO
    {
        public string RoomName { get; set; }
        public long TopicId { get; set; }
    }
}

using Forum.BLL.DataTransferObjects.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface IRoomService
    {
        RoomDTO GetRoomDetails(long Id);
    }
}

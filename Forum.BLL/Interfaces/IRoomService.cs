using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface IRoomService
    {
        RoomDTO GetRoomDetails(long Id);
        void CreateRoom(CreateRoomDTO roomDTO);
        PagedResult<RoomDTO> GetRoomsByTopic(long TopicId,PagedRequestDescription pagedRequestDescription);
    }
}

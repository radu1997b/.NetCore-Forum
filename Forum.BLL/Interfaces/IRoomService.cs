using Cross_cutting.Interfaces;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Room;
using System.Collections.Generic;

namespace Forum.BLL.Interfaces
{
    public interface IRoomService :IScopedService
    {
        RoomDTO GetRoomDetails(long Id);
        void CreateRoom(CreateRoomDTO roomDTO);
        PagedResult<RoomDTO> GetRoomsPaginated(PagedRequestDescription pagedRequestDescription);
        PagedResult<RoomDTO> GetRoomsByTopic(long TopicId,PagedRequestDescription pagedRequestDescription);
        IList<RoomDTO> GetLatestRooms();
        IList<RoomDTO> GetFavoriteRooms(string UserId);
        IList<RoomDTO> GetPopularRooms();
    }
}

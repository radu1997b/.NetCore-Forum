using Cross_cutting.Interfaces;

namespace Forum.BLL.Interfaces
{
    public interface ISubscriptionService : IScopedService
    {
        void Subscribe(string UserId, long RoomId);
        void UnSubscribe(string UserId, long RoomId);
        bool GetSubscriptionStatusForUser(string UserId,long RoomId);
    }
}

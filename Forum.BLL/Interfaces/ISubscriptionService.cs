using Forum.BLL.DataTransferObjects.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface ISubscriptionService
    {
        void Subscribe(SubscriptionsDTO subscription);
        void UnSubscribe(SubscriptionsDTO subscription);
        bool GetSubscriptionStatusForUser(string UserId,long RoomId);
    }
}

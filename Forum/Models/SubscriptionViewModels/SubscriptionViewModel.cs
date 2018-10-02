using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.SubscriptionViewModels
{
    public class SubscriptionViewModel
    {
        public bool IsSubscribed { get; set; }
        public long RoomId { get; set; }
    }
}

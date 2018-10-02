using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.SubscriptionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.RoomViewModels
{
    public class RoomViewModel
    {
        public long RoomId { get; set; }
        public string TopicName { get; set; }
        public string RoomName { get; set; }
        public int NumberOfPosts { get; set; }
        public bool IsSubscribed { get; set; }
        public IList<PostViewModel> PostList { get; set; }
        public int NumberOfPages { get {
                if (NumberOfPosts % 10 == 0)
                    return NumberOfPosts / 10;
                return NumberOfPosts / 10 + 1;
            }
        }
        public SubscriptionViewModel subscriptionViewModel => new SubscriptionViewModel
        {
            RoomId = RoomId,
            IsSubscribed = IsSubscribed
        };

    }
}

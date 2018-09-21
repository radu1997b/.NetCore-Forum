using Forum.Web.Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.RoomViewModels
{
    public class RoomViewModel
    {
        public string TopicName { get; set; }
        public string RoomName { get; set; }
        public int NumberOfPosts { get; set; }
    }
}

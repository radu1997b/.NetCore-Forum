using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.RoomViewModels
{
    public class RoomPartialViewModel
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public int NumberOfPosts { get; set; }
        public DateTime CreationDate { get; set; }
        public string TopicName { get; set; }
    }
}
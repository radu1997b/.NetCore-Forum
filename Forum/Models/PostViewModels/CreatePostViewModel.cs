using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.PostViewModels
{
    public class CreatePostViewModel
    {

        public long RoomId { get; set; }
        public string Message { get; set; }
    }
}

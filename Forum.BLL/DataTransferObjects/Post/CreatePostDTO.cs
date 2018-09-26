using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Post
{
    public class CreatePostDTO
    {
        public long RoomId { get; set; }
        public string AuthorId { get; set; }
        public string Message { get; set; }
    }
}

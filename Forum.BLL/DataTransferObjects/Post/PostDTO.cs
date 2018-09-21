using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.DataTransferObjects.Post
{
    public class PostDTO
    {
        public string AuthorId { get; set; }
        public string AuthorFullName { get; set; }
        public DateTime PostDate { get; set; }
        public int AuthorNumberOfPosts { get; set; }
        public string AuthorEmail { get; set; }
        public string Message { get; set; }
    }
}

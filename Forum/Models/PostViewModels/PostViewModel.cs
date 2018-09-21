using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.PostViewModels
{
    public class PostViewModel
    {
        public string AuthorId { get; set; }
        public string AuthorFullName { get; set; }
        public int AuthorNumberOfPosts { get; set; }
        public DateTime PostDate { get; set; }
        public string Message { get; set; }
        public string AuthorEmail { get; set; }
    }
}

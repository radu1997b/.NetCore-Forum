using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.PostViewModels
{
    public class CreatePostViewModel
    {

        public long RoomId { get; set; }
        [MaxLength(3000)]
        public string Message { get; set; }
    }
}

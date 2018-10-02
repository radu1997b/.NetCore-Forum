using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.RoomViewModels
{
    public class CreateRoomViewModel
    {
        [MaxLength(50)]
        public string RoomName { get; set; }
        public long TopicId { get; set; }
    }
}

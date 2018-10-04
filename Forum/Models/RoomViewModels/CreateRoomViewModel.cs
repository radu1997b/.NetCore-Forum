using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.RoomViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        [MaxLength(50)]
        public string RoomName { get; set; }
        [Display(Name = "Topic Name")]
        public long TopicId { get; set; }
        public IEnumerable<SelectListItem> ListOfTopics { get; set; }
    }
}

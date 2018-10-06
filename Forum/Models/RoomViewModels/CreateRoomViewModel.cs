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
        [Required(ErrorMessage = "Topic Name is required!")]
        [MaxLength(50,ErrorMessage = "Length must be maximium 50 characters")]
        public string RoomName { get; set; }
        [Display(Name = "Topic Name")]
        [Required(ErrorMessage = "Topic is required")]
        public long TopicId { get; set; }
        public IEnumerable<SelectListItem> ListOfTopics { get; set; }
    }
}

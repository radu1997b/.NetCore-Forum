using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Areas.AdminPanel.Models.AdminViewModels
{
    public class TopicCreateViewModel
    {
        [Required]
        [MaxLength(30,ErrorMessage = "Length must be not greater than 30")]
        public string TopicName { get; set; }
    }
}

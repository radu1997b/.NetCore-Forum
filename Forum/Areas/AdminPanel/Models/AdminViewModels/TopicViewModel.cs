using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Areas.AdminPanel.Models.AdminViewModels
{
    public class TopicViewModel
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string TopicName { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

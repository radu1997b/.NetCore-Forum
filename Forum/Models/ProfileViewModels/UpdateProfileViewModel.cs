using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.ProfileViewModels
{
    public class UpdateProfileViewModel
    {
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yy-mm-dd}")]
        public DateTime? DateOfBirth { get; set; }
    }
}

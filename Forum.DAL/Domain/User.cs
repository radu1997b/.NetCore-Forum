using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Forum.DAL.Domain
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserPhotoPath { get; set; } = "~/wwwroot/images/NoImage.jpg";
        public virtual ICollection<UserRoom> UserRooms { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
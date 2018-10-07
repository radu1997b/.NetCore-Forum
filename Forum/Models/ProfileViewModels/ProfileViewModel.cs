using Cross_cutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "Simple User";
        public DateTime? DateOfBirth { get; set; }
        public bool IsHisAccount { get; set; }
        public int NumberOfPosts { get; set; }
        public string UserPhotoPath { get; set; }
        public int Age => DateOfBirth.Value.GetAge();
    }
}

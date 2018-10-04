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
        public string Role { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsHisAccount { get; set; }
        public int NumberOfPosts { get; set; }
        public string UserPhotoPath { get; set; }
        public int Age
        {
            get
            {
                if (DateOfBirth == null)
                    return 0;
                DateTime today = DateTime.Now;
                int age = today.Year - DateOfBirth.Value.Year;
                if (DateOfBirth.Value > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}

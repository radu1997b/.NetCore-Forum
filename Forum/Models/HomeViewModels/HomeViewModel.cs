using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Forum.Web.Models.PostViewModels;
using Forum.Web.Models.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public IList<RoomPartialViewModel> LatestRooms { get; set; }
        public IList<RoomPartialViewModel> PopularRooms { get; set; }
        public IList<RoomPartialViewModel> FavoriteRooms { get; set; }
    }
}

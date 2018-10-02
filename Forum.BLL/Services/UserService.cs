using Cross_cutting.Exceptions;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Forum.BLL.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> userManager;
        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        //TODO Service should not know anything about http
        public string GetUserId(HttpContext context)
        {
            return userManager.GetUserId(context.User);
        }
        public string GetUserRole(string UserId)
        {
            var user = userManager.FindByIdAsync(UserId).Result;
            if (user == null)
                throw new HttpStatusCodeException((int)HttpStatusCode.NotFound, "User Not found");
            var userRole = (userManager.GetRolesAsync(user).Result).FirstOrDefault();
            if (userRole == null)
                userRole = "Standart user";
            return userRole;
        }
    }
}

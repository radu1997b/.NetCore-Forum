using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> userManager;
        public string GetUserId(HttpContext context)
        {
            return userManager.GetUserId(context.User);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Interfaces
{
    public interface IUserService
    {
        string GetUserId(HttpContext context);
    }
}

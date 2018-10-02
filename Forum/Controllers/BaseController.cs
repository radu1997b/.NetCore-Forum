using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class BaseController : Controller
    {
        protected void AddErrors(string ErrorMessage)
        {
             ModelState.AddModelError(string.Empty, ErrorMessage);
        }
        protected IActionResult RedirectToHomePage()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
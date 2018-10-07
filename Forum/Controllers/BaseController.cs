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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Forum.Web.Models.ProfileViewModels;
using Forum.DAL.Domain;

namespace Forum.Web.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;
        public ProfileController(UserManager<User> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [Authorize]
        public async Task<IActionResult> ProfileInfo(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return View("~/Views/Profile/UserNotFound.cshtml");
            }
            //use mapping
            var model = new ProfileViewModel
            {
                Id = Id,
                FullName = user.FirstName + " " + user.LastName, 
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Role = "Admin",
                Stars = 4
            };
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var currentUserId = _userManager.GetUserId(User);
            if(user != null && user.Id != currentUserId)
            {
                return View("~/Views/Shared/AccessDennied.cshtml");
            }
            var userModel = _mapper.Map<UpdateProfileViewModel>(user);
            //remove viewdata
            ViewData["Id"] = Id;
            return View(userModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model,string Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(UpdateProfile), new { Id });
            }
            var user = await _userManager.FindByIdAsync(Id);
            _mapper.Map(model, user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ProfileInfo), new { Id });
            }
            //Something went wrong
            AddErrors(result);
            return View(model);
        }

        //TODO
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
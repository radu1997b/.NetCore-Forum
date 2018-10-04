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
using Forum.BLL.Interfaces;
using Cross_cutting.Exceptions;
using System.Net;

namespace Forum.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private UserManager<User> _userManager;
        private IPhotoService _photoService;
        private IMapper _mapper;
        public ProfileController(UserManager<User> userManager,IMapper mapper,IPhotoService photoService)
        {
            _userManager = userManager;
            _photoService = photoService;
            _mapper = mapper;
        }
        [Authorize]
        public async Task<IActionResult> ProfileInfo(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if(user == null)
                throw new HttpStatusCodeException((int)HttpStatusCode.NotFound, "User not found");
            var model = _mapper.Map<User, ProfileViewModel>(user);
            model.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (model.Role == null)
                model.Role = "Simple User";
            return View(model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                throw new HttpStatusCodeException((int)HttpStatusCode.NotFound, "User not found");
            var currentUserId = _userManager.GetUserId(User);
            if (user != null && user.Id != currentUserId)
                throw new HttpStatusCodeException((int)HttpStatusCode.Unauthorized, "You can't access this resource!");
            var userModel = _mapper.Map<UpdateProfileViewModel>(user);
            userModel.Id = Id;
            return View(userModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model,string Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ProfileController.UpdateProfile), new { Id });
            }
            var user = await _userManager.FindByIdAsync(Id);
            _mapper.Map(model, user);
            var photoPath = (await _photoService.AddImage(model.ImageInfo));
            if (photoPath != null)
                user.UserPhotoPath = photoPath;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    AddErrors(error.Description);
                return View(model);
            }
            return RedirectToAction(nameof(ProfileController.ProfileInfo), new { Id });
        }

    }
}
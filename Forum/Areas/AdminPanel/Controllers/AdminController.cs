using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Cross_cutting.PageHelperClasses;
using Forum.Web.Controllers;

namespace Forum.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Owner")]
    public class AdminController : TopicController
    {
        public AdminController(ITopicService topicService, IMapper mapper)
            : base(topicService, mapper)
        {   }
        public IActionResult Topic()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult DeleteTopic(long id)
        {
            _topicService.Delete(id);
            return new JsonResult(new { result = "Succes" });
        }
        [HttpPost]
        public ActionResult CreateTopic(TopicCreateViewModel model)
        {
        
            if (!ModelState.IsValid)
            {
                AddErrors("Invalid attempt to create a new resource");
                return RedirectToAction(nameof(Topic));
            }
            _topicService.CreateTopic(model.TopicName);
            return RedirectToAction(nameof(Topic));
        }
        [HttpPost]
        public ActionResult UpdateTopic(TopicUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddErrors("Invalid attempt to update resource");
                return RedirectToAction(nameof(Topic));
            }
            var dto = _mapper.Map<TopicUpdateViewModel, TopicDTO>(model);
            _topicService.Update(dto);
            return RedirectToAction(nameof(Topic));
        }
    }
}
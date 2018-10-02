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

namespace Forum.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Owner")]
    public class AdminController : Controller
    {
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        ITopicService _topicService;
        IMapper _mapper;
        public AdminController(UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager,
                               ITopicService topicService,
                               IMapper mapper
                               )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _topicService = topicService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        //TODO Create c class for data table params PagedRequestDescription for example
        //TODO Default values should be set when Data Table is created
        //TODO Create PaginatedList that will be sent in JSON
        [HttpGet]
        public IActionResult LoadTopics(PagedRequestDescription pagedRequestDescription)
        {
            
            var topicsDTO = _topicService.GetTopicsPage(pagedRequestDescription);
            var result = new
            {
                recordsTotal = topicsDTO.AllItemsCount,
                recordsFiltered = topicsDTO.AllItemsCount,
                data = _mapper.Map<ICollection<TopicDTO>, ICollection<TopicViewModel>>(topicsDTO.result)
            };
            return Json(result);
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
                ModelState.AddModelError(string.Empty, "Invalid attempt to create a new resource");
                return RedirectToAction(nameof(Index));
            }
            _topicService.CreateTopic(model.TopicName);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult UpdateTopic(TopicUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid attempt to update resource");
                return RedirectToAction(nameof(Index));
            }
            var dto = _mapper.Map<TopicUpdateViewModel, TopicDTO>(model);
            _topicService.Update(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
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
        [HttpGet]
        public IActionResult LoadTopics(int pageIndex,int pageLength,string sortColumn="Id",string sortOrder="asc",string searchValue="")
        {
     
            IEnumerable<TopicDTO> result;
            result = _topicService.GetTopicsPage(pageIndex, pageLength,searchValue,sortColumn,sortOrder);
            var topics = _mapper.Map<IEnumerable<TopicDTO>, IEnumerable<TopicViewModel>>(result);
            var allTopicCount = _topicService.GetNumberOfTopics();
            return Json(new {recordsFiltered = allTopicCount, recordsTotal = allTopicCount, data = topics.ToList() });
        }
        [HttpDelete]
        public ActionResult DeleteTopic(long id)
        {
            _topicService.Delete(id);
            return new JsonResult(new { result = "Succes" });
        }
        [HttpPost]
        public ActionResult CreateTopic(TopicViewModel model)
        {
            model.TopicCreationDate = DateTime.Now;
            var modelToDTO = _mapper.Map<TopicViewModel, TopicDTO>(model);
            _topicService.CreateTopic(modelToDTO);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CreateTopic(TopicUpdateViewModel model)
        {
            var dto = _mapper.Map<TopicUpdateViewModel, TopicDTO>(model);
            _topicService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
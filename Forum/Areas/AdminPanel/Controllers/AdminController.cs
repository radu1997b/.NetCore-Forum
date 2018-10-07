using AutoMapper;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Interfaces;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                _topicService.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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
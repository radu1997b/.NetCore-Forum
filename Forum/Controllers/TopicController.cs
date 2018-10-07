using System.Collections.Generic;
using AutoMapper;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Interfaces;
using Forum.Web.Areas.AdminPanel.Models.AdminViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class TopicController : BaseController
    {
        protected ITopicService _topicService;
        protected IMapper _mapper;
        public TopicController(ITopicService topicService,IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
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
    }
}
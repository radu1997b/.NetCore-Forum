using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cross_cutting.Extensions;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class SubscriptionsController : Controller
    {
        private ISubscriptionService _subscriptionService;
        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpGet]
        public IActionResult Subscribe(long Id)
        {
            var userId = HttpContext.User.GetUserId();
            var subscritpionDto = new SubscriptionsDTO
            {
                RoomId = Id,
                UserId = userId
            };
            //TODO Pass here two params
            _subscriptionService.Subscribe(subscritpionDto);
             return RedirectToAction("GetRoom", "Room", new { Id });
        }
        public IActionResult UnSubscribe(long Id)
        {
            var userId = HttpContext.User.GetUserId();
            var subscriptionDto = new SubscriptionsDTO
            {
                RoomId = Id,
                UserId = userId
            };
            //TODO Pass here two params
            _subscriptionService.UnSubscribe(subscriptionDto);
            return RedirectToAction("GetRoom", "Room", new { Id });
        }
    }
}
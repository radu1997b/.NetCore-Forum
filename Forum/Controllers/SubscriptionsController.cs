﻿using System;
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
    public class SubscriptionsController : BaseController
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
            _subscriptionService.Subscribe(userId,Id);
             return RedirectToAction("GetRoom", "Room", new { Id });
        }
        public IActionResult UnSubscribe(long Id)
        {
            var userId = HttpContext.User.GetUserId();
            _subscriptionService.UnSubscribe(userId,Id);
            return RedirectToAction("GetRoom", "Room", new { Id });
        }
    }
}
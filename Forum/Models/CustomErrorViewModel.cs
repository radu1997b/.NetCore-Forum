﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models
{
    public class CustomErrorViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

﻿using Cross_cutting.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Models.ProfileViewModels
{
    public class UpdateProfileViewModel
    {
        public string Id { get; set; }
        public string UserPhotoPath { get; set; }
        [Photo(ErrorMessage = "File extension must be jpg,jpeg or png")]
        public IFormFile ImageInfo { get; set; }
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yy-mm-dd}")]
        public DateTime? DateOfBirth { get; set; }
    }
}

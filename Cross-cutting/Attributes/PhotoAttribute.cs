using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Cross_cutting.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhotoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (!(value is IFormFile))
                    throw new ArgumentException(nameof(value));
                var photo = value as IFormFile;
                string extension = Path.GetExtension((photo).FileName);
                if (extension.Equals(".png", StringComparison.InvariantCultureIgnoreCase) ||
                        extension.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase) ||
                        extension.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase))
                    return true;
                else
                {
                    ErrorMessage = "Please Add a image with extension '.png' '.jpeg.' '.jpg'";
                    return false;
                }
            }
            return true;
        }
    }
}


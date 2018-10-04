using Forum.BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private IHostingEnvironment _environment;
        public PhotoService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> AddImage(IFormFile fileInfo)
        {
            if (fileInfo == null)
                return null;
            string imageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileInfo.FileName)}";
            string filePath = $"{_environment.WebRootPath}\\UserPhotos\\{imageName}";
            string returnPath = $"\\UserPhotos\\{imageName}";
            await fileInfo.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return returnPath;
        }
    }
}

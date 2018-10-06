using Cross_cutting.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Interfaces
{
    public interface IPhotoService : IScopedService
    {
        Task<string> AddImage(IFormFile fileInfo);
    }
}

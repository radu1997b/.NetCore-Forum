using Cross_cutting.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Forum.BLL.Interfaces
{
    public interface IPhotoService : IScopedService
    {
        Task<string> AddImage(IFormFile fileInfo);
    }
}

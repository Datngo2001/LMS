using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace API.Interfaces
{
    public interface IUploadService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<VideoUploadResult> AddVideoAsync(IFormFile file);
        Task<DeletionResult> DeleteAsync(string publicId);
    }
}
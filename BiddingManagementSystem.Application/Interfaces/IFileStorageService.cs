using Microsoft.AspNetCore.Http;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        Task<bool> FileExistsAsync(string filePath);
        Task DeleteFileAsync(string filePath);
    }
}


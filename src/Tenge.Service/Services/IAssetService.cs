using Microsoft.AspNetCore.Http;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;

namespace Tenge.Service.Services;

public interface IAssetService
{
    ValueTask<Asset> UploadAsync(IFormFile file, FileType type);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Asset> GetByIdAsync(long id);
}

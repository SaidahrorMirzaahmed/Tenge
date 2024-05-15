using Microsoft.AspNetCore.Http;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Models.Assets;

namespace Tenge.Service.Services.Service;

public interface IAssetService
{
    ValueTask<AssetViewModel> UploadAsync(AssetCreateModel model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AssetViewModel> GetByIdAsync(long id);
}

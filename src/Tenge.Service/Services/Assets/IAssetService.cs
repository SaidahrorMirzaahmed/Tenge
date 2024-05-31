using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Models.Assets;

namespace Tenge.Service.Assets.Service;

public interface IAssetService
{
    ValueTask<AssetViewModel> UploadAsync(AssetCreateModel model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AssetViewModel> GetByIdAsync(long id);
}

using Tenge.Service.Configurations;
using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Items;

namespace Tenge.WebApi.ApiServices.Items;

public interface IItemApiService
{
    ValueTask<ItemViewModel> PostAsync(ItemCreateModel createModel, bool isAdmin);
    ValueTask<ItemViewModel> PutAsync(long id, ItemUpdateModel updateModel, bool isAdmin);
    ValueTask<bool> DeleteAsync(long id, bool isAdmin);
    ValueTask<IEnumerable<ItemViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<ItemViewModel>> GetItemsByCollectionId(long id);
    ValueTask<ItemViewModel> GetAsync(long id);
    ValueTask<bool> DeletePictureAsync(long id);
    ValueTask<AssetViewModel> UploadPictureAsync(long id, AssetCreateModel assetCreateModel);
}
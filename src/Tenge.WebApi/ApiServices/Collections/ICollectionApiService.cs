using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Collections;

namespace Tenge.WebApi.ApiServices.Collections;

public interface ICollectionApiService
{
    ValueTask<CollectionViewModel> PostAsync(CollectionCreateModel createModel);
    ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel, bool isAdmin);
    ValueTask<bool> DeleteAsync(long id, bool isAdmin);
    ValueTask<IEnumerable<CollectionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<CollectionViewModel> GetAsync(long id);
    ValueTask<bool> DeletePictureAsync(long id);
    ValueTask<AssetViewModel> UploadPictureAsync(long id, AssetCreateModel assetCreateModel);
    ValueTask<IEnumerable<CollectionViewModel>> GetbyUserIdAsync(long id, PaginationParams @params, Filter filter, string search = null);
}

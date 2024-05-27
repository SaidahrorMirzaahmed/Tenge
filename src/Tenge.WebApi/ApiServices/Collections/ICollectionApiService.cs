using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Collections;

namespace Tenge.WebApi.ApiServices.Collections;

public interface ICollectionApiService
{
    ValueTask<CollectionViewModel> PostAsync(CollectionCreateModel createModel);
    ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel, bool isAdmin);
    ValueTask<bool> DeleteAsync(long id, bool isAdmin);
    ValueTask<IEnumerable<CollectionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<CollectionViewModel> GetAsync(long id);
}

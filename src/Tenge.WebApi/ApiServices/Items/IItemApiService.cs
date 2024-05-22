using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Items;

namespace Tenge.WebApi.ApiServices.Items;

public interface IItemApiService
{
    ValueTask<ItemViewModel> PostAsync(ItemCreateModel createModel);
    ValueTask<ItemViewModel> PutAsync(long id, ItemUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<ItemViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<ItemViewModel> GetAsync(long id);
}
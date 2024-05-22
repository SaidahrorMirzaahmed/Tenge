using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.ApiServices.Categories;

public interface ICategoryApiService
{
    ValueTask<CategoryViewModel> PostAsync(CategoryCreateModel createModel);
    ValueTask<CategoryViewModel> PutAsync(long id, CategoryUpdateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CategoryViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CategoryViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}

using AutoMapper;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Services.Categories;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Extensions;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Validators.Categories;

namespace Tenge.WebApi.ApiServices.Categories;

public class CategoryApiService(IMapper mapper,
    ICategoryService service,
    CategoryCreateModelValidator validations,
    CategoryUpdateModelValidator validationRules) : ICategoryApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await service.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<CategoryViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var res =await service.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CategoryViewModel>>(res);
    }

    public async ValueTask<CategoryViewModel> GetAsync(long id)
    {
        var res =await service.GetByIdAsync(id);
        return mapper.Map<CategoryViewModel>(res);
    }

    public async ValueTask<CategoryViewModel> PostAsync(CategoryCreateModel createModel)
    {
        await validations.EnsureValidatedAsync(createModel);
        var res = await service.CreateAsync(mapper.Map<Category>(createModel));

        return mapper.Map<CategoryViewModel>(res);
    }

    public async ValueTask<CategoryViewModel> PutAsync(long id, CategoryUpdateModel updateModel)
    {
        await validationRules.EnsureValidatedAsync(updateModel);
        var res = await service.UpdateAsync(id, mapper.Map<Category>(updateModel));

        return mapper.Map<CategoryViewModel>(res);
    }
}

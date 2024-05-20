using AutoMapper;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Services.Collections;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Collections;
using Tenge.WebApi.Validators.Collections;

namespace Tenge.WebApi.ApiServices.Collections;

public class CollectionApiService(
    IMapper mapper,
    ICollectionService service,
    CollectionCreateModelValidator validations,
    CollectionUpdateModelValidator validationRules) : ICollectionApiService 
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await service.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<CollectionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var res = service.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CollectionViewModel>>(res);
    }

    public async ValueTask<CollectionViewModel> GetAsync(long id)
    {
        var existCollection = await service.GetAsync(id);
        return mapper.Map<CollectionViewModel>(existCollection);
    }

    public async ValueTask<CollectionViewModel> PostAsync(CollectionCreateModel createModel)
    {
        var model = mapper.Map<Collection>(createModel);
        var res = service.CreateAsync(model);

        return mapper.Map<CollectionViewModel>(res);
    }

    public async ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel)
    {
        var model = mapper.Map<Collection>(updateModel);
        var res = await service.UpdateAsync(id, model);

        return mapper.Map<CollectionViewModel>(res);
    }
}
using AutoMapper;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Helpers;
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
    public async ValueTask<bool> DeleteAsync(long id, bool isAdmin)
    {
        return await service.DeleteAsync(id, isAdmin);
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
        model.UserId = HttpContextHelper.UserId;
        var res =await service.CreateAsync(model);

        return mapper.Map<CollectionViewModel>(res);
    }

    public async ValueTask<CollectionViewModel> PutAsync(long id, CollectionUpdateModel updateModel, bool isAdmin)
    {
        var model = mapper.Map<Collection>(updateModel);
        var res = await service.UpdateAsync(id, model, isAdmin);

        return mapper.Map<CollectionViewModel>(res);
    }
}
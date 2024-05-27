using AutoMapper;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Services.Items;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Extensions;
using Tenge.WebApi.Models.Items;

namespace Tenge.WebApi.ApiServices.Items;

public class ItemApiService(
    IMapper mapper,
    IItemService service,
    ItemCreateModelValidator validations,
    ItemUpdateModelValidator validationRules
    ) : IItemApiService

{
    public async ValueTask<bool> DeleteAsync(long id, bool isAdmin)
    {
        return await service.DeleteAsync(id, isAdmin);
    }

    public async ValueTask<IEnumerable<ItemViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var res = await service.GetAll(@params, filter, search);
        return mapper.Map<IEnumerable<ItemViewModel>>(res);
    }

    public async ValueTask<ItemViewModel> GetAsync(long id)
    {
        var res = await service.GetAsync(id);
        return mapper.Map<ItemViewModel>(res);
    }

    public async ValueTask<ItemViewModel> PostAsync(ItemCreateModel createModel, bool isAdmin)
    {
        await validations.EnsureValidatedAsync(createModel);
        var model = mapper.Map<Item>(createModel);
        var createdItem = await service.CreateAsync(model, isAdmin);

        return mapper.Map<ItemViewModel>(createdItem);
    }

    public async ValueTask<ItemViewModel> PutAsync(long id, ItemUpdateModel updateModel, bool isAdmin)
    {
        await validationRules.EnsureValidatedAsync(updateModel);
        var model = mapper.Map<Item>(updateModel);
        var updatedItem = await service.UpdateAsync(id, model, isAdmin);

        return mapper.Map<ItemViewModel>(updatedItem);
    }
}

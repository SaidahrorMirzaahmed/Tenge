using AutoMapper;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Assets.Service;
using Tenge.Service.Configurations;
using Tenge.Service.Helpers;
using Tenge.Service.Services.Assets.Assets;
using Tenge.Service.Services.Items;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Extensions;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Items;

namespace Tenge.WebApi.ApiServices.Items;

public class ItemApiService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IAssetService assetService,
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
    public async ValueTask<AssetViewModel> UploadPictureAsync(long id, AssetCreateModel assetCreateModel)
    {
        var collection = await service.GetAsync(id);
        var asset = await assetService.UploadAsync(assetCreateModel);

        collection.PictureId = asset.Id;
        collection.Picture = new Asset
        {
            CreatedAt = DateTime.UtcNow,
            Name = asset.Name,
            Path = asset.Path,
            UpdatedByUserId = HttpContextHelper.UserId
        };
        await unitOfWork.SaveAsync();
        return asset;
    }

    public async ValueTask<bool> DeletePictureAsync(long id)
    {
        var collection = await service.GetAsync(id);
        if (collection.PictureId != null)
        {
            await assetService.DeleteAsync(collection.PictureId.Value);
        }
        collection.PictureId = null;
        collection.Picture = null;
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<ItemViewModel>> GetItemsByCollectionId(long id)
    {
        return mapper.Map<IEnumerable<ItemViewModel>>(await service.GetItemsByCollectionId(id));
    }
}

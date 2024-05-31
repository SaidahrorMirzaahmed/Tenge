using AutoMapper;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Assets.Service;
using Tenge.Service.Configurations;
using Tenge.Service.Helpers;
using Tenge.Service.Services.Assets.Assets;
using Tenge.Service.Services.Collections;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Models.Collections;
using Tenge.WebApi.Validators.Collections;

namespace Tenge.WebApi.ApiServices.Collections;

public class CollectionApiService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IAssetService assetService,
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
        var res = await service.GetAllAsync(@params, filter, search);
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

    public async ValueTask<IEnumerable<CollectionViewModel>> GetbyUserIdAsync(long id, PaginationParams @params, Filter filter, string search = null)
    {
        var collections =await GetAllAsync(@params, filter, search);
        var final = collections.ToList().Where(u=>u.User.Id == id);
        return final;
    }
}
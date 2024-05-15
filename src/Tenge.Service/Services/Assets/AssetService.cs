using AutoMapper;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Exceptions;
using Tenge.Service.Extensions;
using Tenge.Service.Helpers;
using Tenge.WebApi.Models.Assets;

namespace Tenge.Service.Assets.Service;

public class AssetService(IUnitOfWork unitOfWork, IMapper mapper) : IAssetService
{
    public async ValueTask<AssetViewModel> UploadAsync(AssetCreateModel model)
    {
        var assetData = await FileHelper.CreateFileAsync(model.File, model.FileType);
        var asset = new Asset()
        {
            Name = assetData.Name,
            Path = assetData.Path,
        };

        asset.Create();
        var createdAsset = await unitOfWork.Assets.InsertAsync(asset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException("Asset is not found");

        await unitOfWork.Assets.DropAsync(existAsset);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<AssetViewModel> GetByIdAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
           ?? throw new NotFoundException("Asset is not found");

        return mapper.Map<AssetViewModel>(existAsset);
    }
}

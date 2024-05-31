using Arcana.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Exceptions;
using Tenge.Service.Helpers;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Items;

public class ItemService(IUnitOfWork unitOfWork) : IItemService
{
    public async ValueTask<Item> CreateAsync(Item item, bool isAdmin)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(u => u.Id == item.CollectionId, includes: ["User"])
            ?? throw new NotFoundException($"Collection with this Id is not found = {item.CollectionId}");
        var items = await unitOfWork.Items.SelectAsQueryable(i=>i.CollectionId == item.CollectionId).ToListAsync();

        var exist = items.Any(i => i.Name == item.Name && !i.IsDeleted);

        if (exist)
            throw new AlreadyExistException("Item with this name already exists");
        
        if (isAdmin || item.Collection.UserId == HttpContextHelper.UserId)
        {
            item.CreatedByUserId = HttpContextHelper.UserId;
            var createdItem = await unitOfWork.Items.InsertAsync(item);
            await unitOfWork.SaveAsync();
            return createdItem;
        }
        else
        {
            throw new CustomException("You do not have permission for this method", 403);
        }
       
    }

    public async ValueTask<bool> DeleteAsync(long id, bool isAdmin)
    {
        var item = await unitOfWork.Items.SelectAsync(c => c.Id == id, includes: ["Picture", "Collection"])
            ?? throw new NotFoundException($"Item with this Id is not found Id= {id}");

        if (isAdmin || item.Collection.UserId == HttpContextHelper.UserId)
        {
            item.DeletedByUserId = HttpContextHelper.UserId;
            await unitOfWork.Items.DeleteAsync(item);
            await unitOfWork.SaveAsync();
            return true;
        }
        else
        {
            throw new CustomException("You do not have permission for this method", 403);
        }
    }

    public async ValueTask<IEnumerable<Item>> GetAll(PaginationParams @params, Filter filter, string search = null)
    {
        var items = unitOfWork.Items
           .SelectAsQueryable(expression: user => !user.IsDeleted, includes: ["Picture", "Collection"], isTracked: false)
           .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            items = items.Where(user =>
                user.Name.ToLower().Contains(search.ToLower()));

        return await items.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Item> GetAsync(long id)
    {
        var existItem = await unitOfWork.Items.SelectAsync(c => c.Id == id, includes: ["Picture", "Collection"])
           ?? throw new NotFoundException($"Item with this Id is not found Id= {id}");

        return existItem;
    }

    public async ValueTask<IEnumerable<Item>> GetItemsByCollectionId(long id)
    {
        var items = await unitOfWork.Items.SelectAsQueryable(i => i.CollectionId == id && !i.IsDeleted, includes: ["Picture", "Collection"]).ToListAsync();
        return items;
    }

    public async ValueTask<Item> UpdateAsync(long id, Item item, bool isAdmin)
    {
        var existItem = await unitOfWork.Items.SelectAsync(c => c.Id == id, includes: ["Picture", "Collection"])
           ?? throw new NotFoundException($"Item with this Id is not found Id= {id}");

        if (isAdmin || existItem.Collection.UserId == HttpContextHelper.UserId)
        {
            existItem.UpdatedAt = DateTime.UtcNow;
            existItem.Id = id;
            existItem.Picture = item.Picture;
            existItem.PictureId = item.PictureId;
            existItem.CustomInt1Value = item.CustomInt1Value;
            existItem.CustomInt2Value = item.CustomInt2Value;
            existItem.CustomInt3Value = item.CustomInt3Value;
            existItem.CustomString1Value = item.CustomString1Value;
            existItem.CustomString2Value = item.CustomString2Value;
            existItem.CustomString3Value = item.CustomString3Value;
            existItem.CustomDate1Value = item.CustomDate1Value;
            existItem.CustomDate2Value = item.CustomDate2Value;
            existItem.CustomDate3Value = item.CustomDate3Value;

            await unitOfWork.SaveAsync();

            return existItem;
        }
        else
        {
            throw new CustomException("You do not have permission for this method", 403);
        }
    }
}

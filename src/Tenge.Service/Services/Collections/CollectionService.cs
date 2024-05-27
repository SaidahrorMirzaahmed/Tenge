using Arcana.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Exceptions;
using Tenge.Service.Helpers;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Collections;

public class CollectionService(IUnitOfWork unitOfWork) : ICollectionService
{
    public async ValueTask<Collection> CreateAsync(Collection collection)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(c => c.Id == collection.CategoryId)
            ?? throw new NotFoundException($"Category with this id is not found={collection.CategoryId}");
        var user = await unitOfWork.Users.SelectAsync(c => c.Id == collection.UserId);

        collection.CreatedByUserId = HttpContextHelper.UserId;
        collection.Category = existCategory;
        collection.User = user;

        var createdCollection = await unitOfWork.Collections.InsertAsync(collection);
        return collection;
    }

    public async ValueTask<bool> DeleteAsync(long id, bool isAdmin)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id)
            ?? throw new NotFoundException($"Collection with this Id is not found Id= {id}");

        if(isAdmin || existCollection.UserId == HttpContextHelper.UserId)
        {
            existCollection.DeletedByUserId = HttpContextHelper.UserId;
            await unitOfWork.Collections.DeleteAsync(existCollection);
            return true;
        }
        else 
        {
            throw new CustomException("You do not have permission for this method", 403);
        }
    }

    public async ValueTask<Collection> GetAsync(long id)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id, includes: ["Picture", "User", "Category"])
            ?? throw new NotFoundException($"Collection with this Id is not found Id= {id}");

        return existCollection;
    }

    public async ValueTask<IEnumerable<Collection>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var categories = unitOfWork.Collections
           .SelectAsQueryable(expression: user => !user.IsDeleted, isTracked: false, includes: ["Picture", "User", "Category"])
           .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            categories = categories.Where(user =>
                user.Name.ToLower().Contains(search.ToLower()));

        return await categories.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Collection> UpdateAsync(long id, Collection collection, bool isAdmin)
    {
        var existCollection = await unitOfWork.Collections.SelectAsync(c => c.Id == id, includes: ["Picture", "User", "Category"])
           ?? throw new NotFoundException($"Collection with this Id is not found Id= {id}");

        if (isAdmin || existCollection.UserId == HttpContextHelper.UserId)
        {
            existCollection.UpdatedByUserId = HttpContextHelper.UserId;

            existCollection.Name = collection.Name;
            existCollection.Category = collection.Category;
            existCollection.Description = collection.Description;
            existCollection.CustomInt1 = collection.CustomInt1;
            existCollection.CustomInt2 = collection.CustomInt2;
            existCollection.CustomInt3 = collection.CustomInt3;
            existCollection.CustomDate1 = collection.CustomDate1;
            existCollection.CustomDate2 = collection.CustomDate2;
            existCollection.CustomDate3 = collection.CustomDate3;
            existCollection.CustomString2 = collection.CustomString2;
            existCollection.CustomString3 = collection.CustomString3;
            existCollection.CustomString1 = collection.CustomString1;
            existCollection.UpdatedByUserId = HttpContextHelper.UserId;

            return existCollection;
        }
        else
        {
            throw new CustomException("You do not have permission for this method", 403);
        }
        
    }
}


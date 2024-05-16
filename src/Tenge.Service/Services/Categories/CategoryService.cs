using Arcana.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Exceptions;
using Tenge.Service.Helpers;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Categories;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    public async ValueTask<Category> CreateAsync(Category category)
    {
        category.CreatedByUserId = HttpContextHelper.UserId;
        var createdUser = await unitOfWork.Categories.InsertAsync(category);
        await unitOfWork.SaveAsync();
        return createdUser;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"User with this Id isnot found");
        existCategory.DeletedByUserId = HttpContextHelper.UserId;

        var res = await unitOfWork.Categories.DeleteAsync(existCategory);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var categories = unitOfWork.Categories
           .SelectAsQueryable(expression: user => !user.IsDeleted, isTracked: false)
           .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            categories = categories.Where(user =>
                user.Name.ToLower().Contains(search.ToLower()));

        return await categories.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<Category> GetByIdAsync(long id)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"User with this Id isnot found");

        return existCategory;
    }

    public async ValueTask<Category> UpdateAsync(long id, Category category)
    {
        var existCategory = await unitOfWork.Categories.SelectAsync(c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"User with this Id isnot found");
        
        existCategory.Id = id;
        existCategory.Name = category.Name;
        existCategory.UpdatedByUserId = HttpContextHelper.UserId;

        return existCategory;
    }
}

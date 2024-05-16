using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Categories;

public interface ICategoryService
{
    ValueTask<Category> CreateAsync(Category category);
    ValueTask<Category> UpdateAsync(long id, Category category);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Category> GetByIdAsync(long id);
    ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}

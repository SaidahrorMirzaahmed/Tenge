using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Collections;

public interface ICollectionService
{
    ValueTask<Collection> CreateAsync(Collection collection);
    ValueTask<Collection> UpdateAsync(long id, Collection collection, bool isAdmin);
    ValueTask<bool> DeleteAsync(long id, bool isAdmin);
    ValueTask<Collection> GetAsync(long id);
    ValueTask<IEnumerable<Collection>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}


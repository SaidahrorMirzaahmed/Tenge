using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Collections;

public interface ICollectionService
{
    ValueTask<Collection> Create(Collection collection);
    ValueTask<Collection> Update(long id, Collection collection);
    ValueTask<bool> Delete(long id);
    ValueTask<Collection> Get(int id);
    ValueTask<IEnumerable<Collection>> GetAll(PaginationParams @params, Filter filter, string search = null);
}


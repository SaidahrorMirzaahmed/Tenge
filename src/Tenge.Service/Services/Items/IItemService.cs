using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Items;

public interface IItemService
{
    ValueTask<Item> CreateAsync(Item item, bool isAdmin);
    ValueTask<Item> UpdateAsync(long id, Item item, bool isAdmin);
    ValueTask<bool> DeleteAsync(long id, bool isAdmin);
    ValueTask<Item> GetAsync(long id);
    ValueTask<IEnumerable<Item>> GetAll(PaginationParams @params, Filter filter, string search = null);
}

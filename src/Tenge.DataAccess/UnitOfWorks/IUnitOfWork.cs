using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenge.DataAccess.Repositories;
using Tenge.Domain.Entities;

namespace Tenge.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<Asset> Assets { get;  }
    IRepository<Category> Categories { get; }
    IRepository<Collection> Collections { get; }
    IRepository<Item> Items { get; }
    IRepository<User> Users { get;  }
    ValueTask<bool> SaveAsync();
}

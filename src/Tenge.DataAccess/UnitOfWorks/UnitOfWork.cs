using Microsoft.EntityFrameworkCore.Storage;
using Tenge.DataAccess.Contexts;
using Tenge.DataAccess.Repositories;
using Tenge.Domain.Entities;

namespace Tenge.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<Asset> Assets { get; }
    public IRepository<Category> Categories { get; }
    public IRepository<Collection> Collections { get; }
    public IRepository<Item> Items { get; }
    public IRepository<User> Users { get; }

    private IDbContextTransaction transaction;

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Assets = new Repository<Asset>(this.context);
        Categories = new Repository<Category>(this.context);
        Collections = new Repository<Collection>(this.context);
        Items = new Repository<Item>(this.context);
        Users = new Repository<User>(this.context);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }

    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}

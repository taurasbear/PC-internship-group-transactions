namespace PC.Group.Transactions.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Infrastructure.Data.DbContext;
using System.Threading;
using System.Threading.Tasks;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly TransactionContext transactionContext;

    protected readonly DbSet<T> dbSet;

    public BaseRepository(TransactionContext transactionContext)
    {
        this.transactionContext = transactionContext;
        this.dbSet = transactionContext.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await this.dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await this.dbSet.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetAsync(long id, CancellationToken cancellationToken)
    {
        return await this.dbSet.FindAsync(id, cancellationToken);
    }

    public void Remove(T entity)
    {
        this.dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        this.dbSet.Update(entity);
    }
}

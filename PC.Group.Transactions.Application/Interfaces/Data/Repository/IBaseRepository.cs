namespace PC.Group.Transactions.Application.Interfaces.Data.Repository;

using PC.Group.Transactions.Domain.Entities;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task<T?> GetAsync(long id, CancellationToken cancellationToken);

    public Task<IList<T>> GetAllAsync(CancellationToken cancellationToken);

    public Task AddAsync(T entity, CancellationToken cancellationToken);

    public void Update(T entity);

    public void Remove(T entity);
}

namespace PC.Group.Transactions.Application.Interfaces.Data;

using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using System;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository UserRepository { get; }

    public Task SaveAsync(CancellationToken cancellationToken);
}

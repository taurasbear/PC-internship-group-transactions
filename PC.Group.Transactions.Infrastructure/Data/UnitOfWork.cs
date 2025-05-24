namespace PC.Group.Transactions.Infrastructure.Data;

using PC.Group.Transactions.Application.Interfaces.Data;
using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Infrastructure.Data.DbContext;
using PC.Group.Transactions.Infrastructure.Data.Repositories;
using System;

public class UnitOfWork : IUnitOfWork
{
    private readonly TransactionContext transactionContext;

    private IUserRepository? userRepository;

    private bool disposed;

    public IUserRepository UserRepository
    {
        get
        {
            return this.userRepository ??= new UserRepository(transactionContext);
        }
    }

    public UnitOfWork(TransactionContext transactionContext)
    {
        this.transactionContext = transactionContext;
    }

    protected virtual void Dispose(bool dispoing)
    {
        if (!disposed && dispoing)
        {
            this.transactionContext.Dispose();
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await this.transactionContext.SaveChangesAsync(cancellationToken);
    }
}

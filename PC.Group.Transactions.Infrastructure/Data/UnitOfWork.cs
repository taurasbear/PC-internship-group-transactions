namespace PC.Group.Transactions.Infrastructure.Data;

using PC.Group.Transactions.Application.Interfaces.Data;
using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Infrastructure.Data.DbContext;
using PC.Group.Transactions.Infrastructure.Data.Repositories;
using System;

public class UnitOfWork : IUnitOfWork
{
    private readonly TransactionContext transactionContext;

    private IGroupRepository? groupRepository;

    private IMemberRepository? memberRepository;

    private ITransactionPortionRepository? transactionPortionRepository;

    private ITransactionRepository? transactionRepository;

    private IUserRepository? userRepository;

    private bool disposed;

    public IGroupRepository GroupRepository
    {
        get
        {
            return this.groupRepository ??= new GroupRepository(transactionContext);
        }
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return this.memberRepository ??= new MemberRepository(transactionContext);
        }
    }

    public ITransactionPortionRepository TransactionPortionRepository
    {
        get
        {
            return this.transactionPortionRepository ??= new TransactionPortionRepository(transactionContext);
        }
    }

    public ITransactionRepository TransactionRepository
    {
        get
        {
            return this.transactionRepository ??= new TransactionRepository(transactionContext);
        }
    }

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

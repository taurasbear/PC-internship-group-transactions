namespace PC.Group.Transactions.Application.Interfaces.Data;

using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using System;

public interface IUnitOfWork : IDisposable
{
    public IGroupRepository GroupRepository { get; }

    public IMemberRepository MemberRepository { get; }

    public ITransactionPortionRepository TransactionPortionRepository { get; }

    public ITransactionRepository TransactionRepository { get; }

    public IUserRepository UserRepository { get; }

    public Task SaveAsync(CancellationToken cancellationToken);
}

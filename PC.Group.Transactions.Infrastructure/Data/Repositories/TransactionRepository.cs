namespace PC.Group.Transactions.Infrastructure.Data.Repositories;

using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Infrastructure.Data.DbContext;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(TransactionContext transactionContext) : base(transactionContext)
    { }
}

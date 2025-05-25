namespace PC.Group.Transactions.Infrastructure.Data.Repositories;

using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Infrastructure.Data.DbContext;

public class MemberRepository : BaseRepository<Member>, IMemberRepository
{
    public MemberRepository(TransactionContext transactionContext) : base(transactionContext)
    { }
}

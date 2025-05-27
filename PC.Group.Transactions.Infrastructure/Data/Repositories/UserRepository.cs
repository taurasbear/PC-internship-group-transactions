namespace PC.Group.Transactions.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Infrastructure.Data.DbContext;
using System.Threading;
using System.Threading.Tasks;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(TransactionContext transactionContext) : base(transactionContext)
    { }

    public async Task<List<User>> GetNonMemberUsersByGroupIdAsync(long groupId, CancellationToken cancellationToken)
    {
        return await this.transactionContext.Users
            .Where(user => user.Members.All(member => member.GroupId != groupId))
            .ToListAsync(cancellationToken);
    }
}

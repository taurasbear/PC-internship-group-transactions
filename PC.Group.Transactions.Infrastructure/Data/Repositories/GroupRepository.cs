namespace PC.Group.Transactions.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Application.Interfaces.Data.Repository;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Infrastructure.Data.DbContext;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(TransactionContext transactionContext) : base(transactionContext)
    { }

    public async Task<List<Group>> GetGroupsDetailsByUserIdAsync(long userId, CancellationToken cancellationToken)
    {
        return await this.transactionContext.Groups
            .Where(group => group.Members.Any(member => member.UserId == userId))
            .Include(group => group.Members)
               .ThenInclude(member => member.TransactionPortions)
            .Include(group => group.Members)
                .ThenInclude(member => member.Transactions)
            .ToListAsync(cancellationToken);
    }

    public async Task<Group?> GetGroupDetailsByGroupIdAsync(long groupId, CancellationToken cancellationToken)
    {
        return await this.transactionContext.Groups
            .Include(group => group.Members)
                .ThenInclude(member => member.Transactions)
                    .ThenInclude(transaction => transaction.TransactionPortions)
            .Include(group => group.Members)
                .ThenInclude(member => member.User)
            .FirstOrDefaultAsync(group => group.Id == groupId, cancellationToken);
    }
}

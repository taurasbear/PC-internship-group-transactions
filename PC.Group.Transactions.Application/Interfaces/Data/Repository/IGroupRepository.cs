namespace PC.Group.Transactions.Application.Interfaces.Data.Repository;

using PC.Group.Transactions.Domain.Entities;

public interface IGroupRepository : IBaseRepository<Group>
{
    public Task<List<Group>> GetGroupsDetailsByUserIdAsync(long userId, CancellationToken cancellationToken);

    public Task<Group?> GetGroupDetailsByGroupIdAsync(long groupId, CancellationToken cancellationToken);
}

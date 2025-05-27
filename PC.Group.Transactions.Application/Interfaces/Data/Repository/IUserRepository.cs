namespace PC.Group.Transactions.Application.Interfaces.Data.Repository;

using PC.Group.Transactions.Domain.Entities;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<List<User>> GetNonMemberUsersByGroupIdAsync(long groupId, CancellationToken cancellationToken);
}

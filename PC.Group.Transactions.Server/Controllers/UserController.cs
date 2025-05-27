namespace PC.Group.Transactions.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("non-members")]
    public async Task<ActionResult<GetNonMemberUsersResponse>> GetNonMemberUsers([FromQuery] long groupId, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(new GetNonMemberUsersRequest(groupId), cancellationToken);

        return this.Ok(response);
    }
}

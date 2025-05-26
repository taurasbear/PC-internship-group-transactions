namespace PC.Group.Transactions.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PC.Group.Transactions.Application.Features.Group.AddGroup;
using PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IMediator mediator;

    public GroupController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("summaries")]
    public async Task<ActionResult<GetGroupsSummariesRequest>> GetGroupsSummaries([FromQuery] long userId, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(new GetGroupsSummariesRequest(userId), cancellationToken);
        return this.Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddGroup([FromBody] AddGroupRequest request, CancellationToken cancellationToken)
    {
        await this.mediator.Send(request, cancellationToken);
        return this.Ok();
    }
}

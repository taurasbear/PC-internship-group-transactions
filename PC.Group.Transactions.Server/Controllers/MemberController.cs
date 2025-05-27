namespace PC.Group.Transactions.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PC.Group.Transactions.Application.Features.Member.AddMember;
using PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMediator mediator;

    public MemberController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("summaries")]
    public async Task<ActionResult<GetMembersSummariesResponse>> GetMembersSummaries([FromQuery] long userId, [FromQuery] long groupId, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(new GetMembersSummariesRequest(userId, groupId), cancellationToken);

        return this.Ok(response);
    }

    [HttpPost()]
    public async Task<IActionResult> AddMember([FromBody] AddMemberRequest request, CancellationToken cancellationToken)
    {
        await this.mediator.Send(request, cancellationToken);
        return this.Ok();
    }
}

namespace PC.Group.Transactions.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator mediator;

    public TransactionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("summaries")]
    public async Task<ActionResult<GetTransactionsSummariesResponse>> GetTransactionsSummaries([FromQuery] long userId, [FromQuery] long groupId, CancellationToken cancellationToken)
    {
        var response = await this.mediator.Send(new GetTransactionsSummariesRequest(userId, groupId), cancellationToken);

        return this.Ok(response);
    }
}

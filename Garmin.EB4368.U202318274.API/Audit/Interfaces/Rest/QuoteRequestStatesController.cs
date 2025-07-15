using System.Net.Mime;
using Garmin.EB4368.U202318274.API.Audit.Domain.Services;
using Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Resources;
using Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available QuoteRequest States endpoints")]
public class QuoteRequestStatesController(
    IQuoteRequestStateCommandService quoteRequestStateCommandService,
    IQuoteRequestStateQueryService quoteRequestStateQueryService
) : ControllerBase
{
    [HttpPost("{quoteRequestId}")]
    [SwaggerOperation(
        Summary = "Create a QuoteRequestState",
        Description = "Creates a new QuoteRequestState and returns the created QuoteRequestState Resource.",
        OperationId = "CreateQuoteRequestState")]
    [SwaggerResponse(StatusCodes.Status201Created, "Quote Request State created successfully",
        typeof(QuoteRequestStateResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Quote Request State could not be created")]
    public async Task<IActionResult> CreateQuoteRequestState([FromBody] CreateQuoteRequestStateResource resource,
        [FromRoute] Guid quoteRequestId)
    {
        var exists = await quoteRequestStateCommandService
            .ValidateQuoteRequestExistsAsync(quoteRequestId);

        if (!exists)
            return BadRequest("QuoteRequestId does not exist in Sales context");

        var createQuoteRequestStateCommand =
            CreateQuoteRequestStateCommandFromResourceAssembler.ToCommandFromResource(resource, quoteRequestId);
        var quoteRequestState = await quoteRequestStateCommandService.Handle(createQuoteRequestStateCommand);
        if (quoteRequestState is null) return BadRequest("quoteRequestState could not be created.");
        var quoteRequestStateResource =
            QuoteRequestStateResourceFromEntityAssembler.ToResourceFromEntity(quoteRequestState);
        return new CreatedResult(string.Empty, quoteRequestStateResource);
    }
}
using System.Net.Mime;
using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Domain.Services;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Things Endpoints")]
public class QuoteRequestsController(
    IQuoteRequestCommandService quoteRequestCommandService,
    IQuoteRequestQueryService quoteRequestQueryService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Quote Request",
        Description = "Creates a new Quote Request and returns the created Quote Request Resource.",
        OperationId = "CreateQuoteRequest")]
    [SwaggerResponse(StatusCodes.Status201Created, "Thing created successfully", typeof(QuoteRequestResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Thing could not be created")]
    public async Task<IActionResult> CreateQuoteRequest([FromBody] CreateQuoteRequestResource resource)
    {
        var createQuoteRequestCommand =
            CreateQuoteRequestCommandFromResourceAssembler.ToCommandFromResource(resource);
        var quoteRequest = await quoteRequestCommandService.Handle(createQuoteRequestCommand);
        if (quoteRequest is null) return BadRequest("quoteRequest could not be created.");
        var quoteRequestResource = QuoteRequestResourceFromEntityAssembler.ToResourceFromEntity(quoteRequest);
        return new CreatedResult(string.Empty, quoteRequestResource);
    }
}
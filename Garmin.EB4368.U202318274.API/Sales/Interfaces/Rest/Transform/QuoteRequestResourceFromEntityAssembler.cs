using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;

namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Transform;

public class QuoteRequestResourceFromEntityAssembler
{
    public static QuoteRequestResource ToResourceFromEntity(QuoteRequest entity)
    {
        return new QuoteRequestResource(
            entity.Id,
            entity.QuoteRequestId.Identifier,
            entity.DealerId.Identifier,
            entity.ProductId.Identifier,
            entity.RequestsUnits,
            entity.RequestedAt,
            entity.State.ToString(),
            entity.Notes
        );
    }
}
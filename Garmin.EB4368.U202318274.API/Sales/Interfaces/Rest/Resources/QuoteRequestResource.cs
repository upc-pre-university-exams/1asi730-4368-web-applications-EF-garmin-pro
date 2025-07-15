namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;

public record QuoteRequestResource(
    int Id,
    Guid QuoteRequestId,
    int DealerId,
    Guid ProductId,
    int RequestsUnits,
    DateTime RequestedAt,
    String State,
    string Notes
);
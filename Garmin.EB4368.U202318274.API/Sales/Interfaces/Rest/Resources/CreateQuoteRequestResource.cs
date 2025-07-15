namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;

public record CreateQuoteRequestResource(
    int RequestUnits,
    int StateId,
    string Notes
);
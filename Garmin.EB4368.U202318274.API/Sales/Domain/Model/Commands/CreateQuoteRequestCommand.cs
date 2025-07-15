namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;

public record CreateQuoteRequestCommand(
    int RequestsUnits,
    int StateId,
    string Notes
);
namespace Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;

public record CreateQuoteRequestStateCommand(
    Guid QuoteRequestId,
    string Notes,
    string StateName,
    DateTime Date
);
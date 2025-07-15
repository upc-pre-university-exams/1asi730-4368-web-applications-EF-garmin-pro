namespace Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Resources;

public record CreateQuoteRequestStateResource(
    Guid QuoteRequestId,
    string State,
    string Notes,
    DateTime Created
 
);
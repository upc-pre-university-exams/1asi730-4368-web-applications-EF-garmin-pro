using Garmin.EB4368.U202318274.API.Shared.Domain.Model.Events;

namespace Garmin.EB4368.U202318274.API.Audit.Domain.Model.Events;

public class QuoteRequestStateCreatedEvent(
    Guid quoteRequestId,
    string notes,
    string stateName,
    DateTime createdOn
) : IEvent

{
    public Guid QuoteRequestId { get; } = quoteRequestId;
    public string Notes { get; } = notes;
    public string StateName { get; } = stateName;
    public DateTime CreatedOn { get; } = createdOn;
}
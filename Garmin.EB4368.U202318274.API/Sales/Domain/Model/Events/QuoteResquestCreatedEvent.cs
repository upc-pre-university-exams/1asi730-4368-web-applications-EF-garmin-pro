using Garmin.EB4368.U202318274.API.Shared.Domain.Model.Events;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.Events;

public class QuoteResquestCreatedEvent(
    int units,
    int stateId,
    string notes
) : IEvent
{
    public int Units { get; } = units;
    public int StateId { get; } = stateId;
    public string Notes { get; } = notes;
}
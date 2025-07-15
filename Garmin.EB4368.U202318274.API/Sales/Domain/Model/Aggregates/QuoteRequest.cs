using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.ValueObjects;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;

public partial class QuoteRequest
{
    public int Id { get; set; }
    public QuoteRequestId QuoteRequestId { get; private set; }
    public DealerId DealerId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int RequestsUnits { get; private set; }
    public DateTime RequestedAt { get; private set; }
    public EQuoteRequestState State { get; private set; }
    public DateTime ValidUntil { get; private set; }
    public string Notes { get; private set; }

    public QuoteRequest()
    {
    }

    public QuoteRequest(CreateQuoteRequestCommand command)
    {
        QuoteRequestId = new QuoteRequestId();
        DealerId = new DealerId();
        ProductId = new ProductId();
        RequestsUnits = command.RequestsUnits;
        RequestedAt = DateTime.Now;
        State = StateToInt(command.StateId);
        ValidUntil = SetValidUntil(RequestedAt);
        Notes = command.Notes;
    }

    public EQuoteRequestState StateToInt(int state)
    {
        return (EQuoteRequestState)state;
    }

    public DateTime SetValidUntil(DateTime requestDate)
    {
        var validUntil = requestDate.AddDays(7);
        return validUntil;
    }

    public void UpdateNotes(string notes)
    {
        Notes = notes;
    }

    public void UpdateState(int stateId)
    {
        State = (EQuoteRequestState)stateId;
    }

    public void UpdateStateInString(string stateName)
    {
        State = (EQuoteRequestState)Enum.Parse(typeof(EQuoteRequestState), stateName);
    }
}
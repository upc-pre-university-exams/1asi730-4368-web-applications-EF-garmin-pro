using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.ValueObjects;

namespace Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;

public class QuoteRequestState
{
    public int Id { get; set; }
    public QuoteRequestIdentifier QuoteRequestIdentifier { get; set; }
    public string Notes { get; set; }
    public string StateName { get; set; }
    public DateTime Date { get; set; }

    public QuoteRequestState()
    {
    }

    public QuoteRequestState(CreateQuoteRequestStateCommand command)
    {
        QuoteRequestIdentifier = new QuoteRequestIdentifier(command.QuoteRequestId);
        Notes = command.Notes;
        StateName = command.StateName;
        Date = DateTime.Now;
    }
}
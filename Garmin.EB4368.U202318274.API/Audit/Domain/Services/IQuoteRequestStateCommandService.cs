using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;

namespace Garmin.EB4368.U202318274.API.Audit.Domain.Services;

public interface IQuoteRequestStateCommandService
{
    Task<QuoteRequestState?> Handle(CreateQuoteRequestStateCommand command);
}
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Queries;

namespace Garmin.EB4368.U202318274.API.Audit.Domain.Services;

public interface IQuoteRequestStateQueryService
{
    Task<QuoteRequestState?> Handle(GetQuoteRequestStateByQuoteRequestId command);
}
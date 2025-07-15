using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;

namespace Garmin.EB4368.U202318274.API.Audit.Domain.Repositories;

public interface IQuoteRequestStateRepository : IBaseRepository<QuoteRequestState>
{
    Task<QuoteRequestState?> FindByQuoteRequestStateByQuoteRequestIdAsync(Guid quoteRequestId);
}
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Queries;
using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Domain.Services;

namespace Garmin.EB4368.U202318274.API.Sales.Application.Internal.QueryServices;

public class QuoteRequestQueryService(IQuoteRequestRepository quoteRequestRepository) : IQuoteRequestQueryService
{
    public async Task<QuoteRequest?> Handle(GetQuoteRequestByQuoteRequestId query)
    {
        return await quoteRequestRepository.FindByQuoteRequestIdAsync(query.QuoteRequestId);
    }
}
using Cortex.Mediator;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Queries;
using Garmin.EB4368.U202318274.API.Audit.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Audit.Domain.Services;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.ACL;
using Garmin.EB4368.U202318274.API.Shared.Domain.Exceptions;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;

namespace Garmin.EB4368.U202318274.API.Audit.Application.Internal.QueryServices;

public class QuoteRequestStateQueryService(IQuoteRequestStateRepository quoteRequestStateRepository)
    : IQuoteRequestStateQueryService
{
    public async Task<QuoteRequestState?> Handle(GetQuoteRequestStateByQuoteRequestId command)
    {
        return await quoteRequestStateRepository.FindByQuoteRequestStateByQuoteRequestIdAsync(command.QuoteRequestId);
    }
}
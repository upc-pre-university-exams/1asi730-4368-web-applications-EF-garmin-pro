using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Queries;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Services;

public interface IQuoteRequestQueryService
{
    Task<QuoteRequest?> Handle(GetQuoteRequestByQuoteRequestId query);
}
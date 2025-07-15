using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;

public interface IQuoteRequestRepository : IBaseRepository<QuoteRequest>
{
    Task<bool> ExistsByQuoteRequestIdAsync(Guid quoteRequestId);
    Task<QuoteRequest?> FindByQuoteRequestIdAsync(Guid quoteRequestId);
    Task<bool> ExistByStateIdAndQuoteRequestIdAsync(int stateId, Guid quoteRequestId);
    Task<bool> UpdateNotesByQuoteRequestIdAsync(Guid quoteRequestId, string notes);
    Task<bool> UpdateStateByQuoteRequestIdAsync(Guid quoteRequestId, string stateName);
    Task<bool> UpdateDateByQuoteRequestIdAsync(Guid quoteRequestId, DateTime date);
}
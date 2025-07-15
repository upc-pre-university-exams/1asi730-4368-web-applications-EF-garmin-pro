using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.ACL;

namespace Garmin.EB4368.U202318274.API.Sales.Application.ACL;

public class SalesContextFacade(IQuoteRequestRepository quoteRequestRepository)
    : ISalesContextFacade
{
    public async Task<bool> ExistQuoteRequestByQuoteRequestIdAsync(Guid quoteRequestId)
    {
        return await quoteRequestRepository.ExistsByQuoteRequestIdAsync(quoteRequestId);
    }

    public async Task<bool> UpdateQuoteRequestStateAsync(Guid quoteRequestId, string state)
    {
        return await quoteRequestRepository.UpdateStateByQuoteRequestIdAsync(quoteRequestId, state);
    }

    public async Task<bool> UpdateQuoteRequestNotesAsync(Guid quoteRequestId, string notes)
    {
        return await quoteRequestRepository.UpdateNotesByQuoteRequestIdAsync(quoteRequestId, notes);
    }

    public Task<bool> UpdateQuoteRequestUpdatedDateAsync(Guid quoteRequestId, DateTime updatedDate)
    {
        return quoteRequestRepository.UpdateDateByQuoteRequestIdAsync(quoteRequestId, updatedDate);
    }
}
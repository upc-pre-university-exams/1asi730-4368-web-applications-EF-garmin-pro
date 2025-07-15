namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.ACL;

public interface ISalesContextFacade
{
    Task<bool> ExistQuoteRequestByQuoteRequestIdAsync(Guid quoteRequestId);
    Task<bool> UpdateQuoteRequestStateAsync(Guid quoteRequestId, string state);
    Task<bool> UpdateQuoteRequestNotesAsync(Guid quoteRequestId, string notes);
    Task<bool> UpdateQuoteRequestUpdatedDateAsync(Guid quoteRequestId, DateTime updatedDate);
    
}
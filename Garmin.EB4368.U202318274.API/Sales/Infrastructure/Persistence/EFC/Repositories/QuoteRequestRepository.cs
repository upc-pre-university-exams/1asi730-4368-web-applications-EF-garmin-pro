using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Garmin.EB4368.U202318274.API.Sales.Infrastructure.Persistence.EFC.Repositories;

public class QuoteRequestRepository(AppDbContext context)
    : BaseRepository<QuoteRequest>(context), IQuoteRequestRepository
{
    public Task<bool> ExistsByQuoteRequestIdAsync(Guid quoteRequestId)
    {
        return Context.Set<QuoteRequest>()
            .AsNoTracking()
            .AnyAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId);
    }

    public Task<QuoteRequest?> FindByQuoteRequestIdAsync(Guid quoteRequestId)
    {
        return Context.Set<QuoteRequest>()
            .AsNoTracking()
            .FirstOrDefaultAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId);
    }

    public async Task<bool> ExistByStateIdAndQuoteRequestIdAsync(int stateId, Guid quoteRequestId)
    {
        var quoteRequest = await Context.Set<QuoteRequest>()
            .FirstOrDefaultAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId && (int)qr.State == stateId);

        if (quoteRequest == null) return false;

        quoteRequest.UpdateState(stateId);
        Update(quoteRequest);
        await Context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> UpdateNotesByQuoteRequestIdAsync(Guid quoteRequestId, string notes)
    {
        var quoteRequest = await Context.Set<QuoteRequest>()
            .FirstOrDefaultAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId);

        if (quoteRequest == null) return false;
        quoteRequest.UpdateNotes(notes);
        Update(quoteRequest);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateStateByQuoteRequestIdAsync(Guid quoteRequestId, string stateId)
    {
        var quoteRequest = await Context.Set<QuoteRequest>()
            .FirstOrDefaultAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId);

        if (quoteRequest == null) return false;
        quoteRequest.UpdateStateInString(stateId);
        Update(quoteRequest);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateDateByQuoteRequestIdAsync(Guid quoteRequestId, DateTime date)
    {
        var quoteRequest = await Context.Set<QuoteRequest>()
            .FirstOrDefaultAsync(qr => qr.QuoteRequestId.Identifier == quoteRequestId);

        if (quoteRequest == null) return false;
        quoteRequest.UpdateDate(date);
        Update(quoteRequest);
        await Context.SaveChangesAsync();
        return true;
    }
}
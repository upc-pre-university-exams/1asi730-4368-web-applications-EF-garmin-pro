using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Garmin.EB4368.U202318274.API.Audit.Infrastructure.Persistence.EFC.Repositories;

public class QuoteRequestStateRepository(AppDbContext context)
    : BaseRepository<QuoteRequestState>(context), IQuoteRequestStateRepository
{
    public async Task<QuoteRequestState?> FindByQuoteRequestStateByQuoteRequestIdAsync(Guid quoteRequestSateId)
    {
        return await Context.Set<QuoteRequestState>()
            .AsNoTracking()
            .FirstOrDefaultAsync(qrs => qrs.QuoteRequestIdentifier.Identifier == quoteRequestSateId);
    }
}
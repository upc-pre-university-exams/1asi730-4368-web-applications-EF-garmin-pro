
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Unit of work implementation
/// </summary>
/// <remarks>
///     This class implements the basic operations for a unit of work.
///     It requires the context to be passed in the constructor.
/// </remarks>
/// <see cref="IUnitOfWork" />
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}
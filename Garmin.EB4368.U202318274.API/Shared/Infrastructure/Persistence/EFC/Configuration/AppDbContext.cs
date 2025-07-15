using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Garmin.EB4368.U202318274.API.Audit.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Garmin.EB4368.U202318274.API.Sales.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply configurations for the Sales bounded context
        builder.ApplySalesConfiguration();
        
        builder.ApplyAuditConfiguration();

        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }
}
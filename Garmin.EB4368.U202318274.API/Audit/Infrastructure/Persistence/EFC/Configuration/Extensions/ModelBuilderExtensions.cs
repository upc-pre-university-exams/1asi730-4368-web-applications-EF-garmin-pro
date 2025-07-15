using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Garmin.EB4368.U202318274.API.Audit.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAuditConfiguration(this ModelBuilder builder)
    {
        builder.Entity<QuoteRequestState>().HasKey(qr => qr.Id);
        builder.Entity<QuoteRequestState>().Property(qr => qr.Id).ValueGeneratedNever();

        builder.Entity<QuoteRequestState>().Property(qr => qr.Notes).IsRequired().HasMaxLength(500);
        builder.Entity<QuoteRequestState>().Property(qr => qr.StateName).IsRequired().HasMaxLength(50);
        builder.Entity<QuoteRequestState>().Property(qr => qr.Date).IsRequired();

        builder.Entity<QuoteRequestState>().OwnsOne(qr => qr.QuoteRequestIdentifier, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(e => e.Identifier).HasColumnName("QuoteRequestId");
        });
    }
}
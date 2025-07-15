using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Garmin.EB4368.U202318274.API.Sales.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySalesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<QuoteRequest>().HasKey(qr => qr.Id);
        builder.Entity<QuoteRequest>().Property(qr => qr.Id).IsRequired().ValueGeneratedOnAdd();


        builder.Entity<QuoteRequest>().Property(qr => qr.RequestsUnits).IsRequired();
        builder.Entity<QuoteRequest>().Property(qr => qr.RequestedAt).IsRequired();
        builder.Entity<QuoteRequest>().Property(qr => qr.State).IsRequired();
        //builder.Entity<QuoteRequest>().Property(qr => qr.State).HasConversion<string>().IsRequired();
        builder.Entity<QuoteRequest>().Property(qr => qr.ValidUntil).IsRequired();
        builder.Entity<QuoteRequest>().Property(qr => qr.Notes).IsRequired().HasMaxLength(500);

        builder.Entity<QuoteRequest>().OwnsOne(qr => qr.QuoteRequestId, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(e => e.Identifier).HasColumnName("QuoteRequestId");
        });

        builder.Entity<QuoteRequest>().OwnsOne(qr => qr.DealerId, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(e => e.Identifier).HasColumnName("DealerId");
        });

        builder.Entity<QuoteRequest>().OwnsOne(qr => qr.ProductId, e =>
        {
            e.WithOwner().HasForeignKey("Id");
            e.Property(e => e.Identifier).HasColumnName("ProductId");
        });
    }
}
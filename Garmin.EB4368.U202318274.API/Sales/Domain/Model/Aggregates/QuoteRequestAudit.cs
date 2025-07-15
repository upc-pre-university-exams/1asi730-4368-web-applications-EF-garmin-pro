using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;

public partial class QuoteRequest : IEntityWithCreatedUpdatedDate
{
    [Column(name: "CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column(name: "UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }

    public void UpdateDate(DateTime date)
    {
        UpdatedDate = date;
    }
}
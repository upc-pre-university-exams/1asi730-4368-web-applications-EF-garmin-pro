namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.ValueObjects;

public record DealerId(int Identifier)
{
    public DealerId() : this(new Random().Next(1, 1000000))
    {
    }
}
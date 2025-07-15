namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.ValueObjects;

public record ProductId(Guid Identifier)
{
    // Random Guid
    public ProductId() : this(Guid.NewGuid())
    {
    }

    public String GuidToString()
    {
        return Identifier.ToString();
    }

    public Guid StringToGuid()
    {
        return Identifier;
    }
}
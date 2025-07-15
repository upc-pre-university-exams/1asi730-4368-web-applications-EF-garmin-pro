namespace Garmin.EB4368.U202318274.API.Sales.Domain.Model.ValueObjects;

public record QuoteRequestId(Guid Identifier)
{
//Add new Random Identifier for QuoteRequestId
    public QuoteRequestId() : this(Guid.NewGuid())
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
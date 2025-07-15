using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Resources;

namespace Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Transform;

public class QuoteRequestStateResourceFromEntityAssembler
{
    public static QuoteRequestStateResource ToResourceFromEntity(QuoteRequestState entity)
    {
        return new QuoteRequestStateResource(
            entity.Id,
            entity.QuoteRequestIdentifier.Identifier,
            entity.StateName,
            entity.Notes,
            entity.Date
        );
    }
}
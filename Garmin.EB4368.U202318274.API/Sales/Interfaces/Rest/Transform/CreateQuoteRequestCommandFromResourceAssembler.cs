using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;

namespace Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Transform;

public class CreateQuoteRequestCommandFromResourceAssembler
{
    public static CreateQuoteRequestCommand ToCommandFromResource(CreateQuoteRequestResource resource)
    {
        return new CreateQuoteRequestCommand(
            resource.RequestUnits,
            resource.StateId,
            resource.Notes
        );
    }
}
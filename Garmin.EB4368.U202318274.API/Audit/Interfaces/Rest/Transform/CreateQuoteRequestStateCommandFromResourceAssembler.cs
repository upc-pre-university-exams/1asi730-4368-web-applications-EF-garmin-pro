﻿using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Resources;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.Rest.Resources;

namespace Garmin.EB4368.U202318274.API.Audit.Interfaces.Rest.Transform;

public class CreateQuoteRequestStateCommandFromResourceAssembler
{
    public static CreateQuoteRequestStateCommand ToCommandFromResource(CreateQuoteRequestStateResource resource, Guid quoteRequestId)
    {
        return new CreateQuoteRequestStateCommand(
            quoteRequestId,
            resource.Notes,
            resource.State,
            resource.Created
        );
    }
}
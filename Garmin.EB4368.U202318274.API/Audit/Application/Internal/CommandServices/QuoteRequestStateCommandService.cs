using Cortex.Mediator;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Events;
using Garmin.EB4368.U202318274.API.Audit.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Audit.Domain.Services;
using Garmin.EB4368.U202318274.API.Sales.Application.Internal.EventHandlers;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Sales.Domain.Services;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.ACL;
using Garmin.EB4368.U202318274.API.Shared.Domain.Exceptions;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;

namespace Garmin.EB4368.U202318274.API.Audit.Application.Internal.CommandServices;

public class QuoteRequestStateCommandService(
    IQuoteRequestStateRepository quoteRequestStateRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher,
    ISalesContextFacade salesContextFacade
) : IQuoteRequestStateCommandService
{
    public async Task<QuoteRequestState?> Handle(CreateQuoteRequestStateCommand command)
    {
        // General Validations
        if (command.QuoteRequestId == Guid.Empty)
            throw new GeneralException("QuoteRequestId cannot be empty", "VALIDATION_ERROR");


        if (command.StateName != "Requested" &&
            command.StateName != "Preparing" &&
            command.StateName != "Sent" &&
            command.StateName != "Completed")
            throw new GeneralException("StateName must be one of the following: Requested, Preparing, Sent, Completed",
                "VALIDATION_ERROR");

        // ACL Validations

        var existsQuoteRequestByQuoteRequestId =
            await salesContextFacade.ExistQuoteRequestByQuoteRequestIdAsync(command.QuoteRequestId);

        if (!existsQuoteRequestByQuoteRequestId)
            throw new GeneralException("QuoteRequestId cannot be null", "VALIDATION_ERROR");


        // Create Instance
        var quoteRequestState = new QuoteRequestState(command);
        await quoteRequestStateRepository.AddAsync(quoteRequestState);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new QuoteRequestStateCreatedEvent(
            quoteRequestState.QuoteRequestIdentifier.Identifier,
            quoteRequestState.Notes,
            quoteRequestState.StateName,
            quoteRequestState.Date
        ));

        // Add Acl configuration

        // Validate the updated operation mode in the inventory context
        var stateModeUpdated = await salesContextFacade.UpdateQuoteRequestStateAsync(
            quoteRequestState.QuoteRequestIdentifier.Identifier,
            quoteRequestState.StateName
        );

        var notesUpdated = await salesContextFacade.UpdateQuoteRequestNotesAsync(
            quoteRequestState.QuoteRequestIdentifier.Identifier,
            quoteRequestState.Notes
        );

        var updatedDate = await salesContextFacade.UpdateQuoteRequestUpdatedDateAsync(
            quoteRequestState.QuoteRequestIdentifier.Identifier,
            quoteRequestState.Date
        );

        if (!stateModeUpdated || !notesUpdated || !updatedDate)
            throw new GeneralException("Error updating QuoteRequest in Sales Context", "INTERNAL_ERROR");

        return quoteRequestState;
    }
}
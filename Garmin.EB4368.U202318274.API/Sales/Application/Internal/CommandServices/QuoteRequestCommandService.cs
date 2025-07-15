using Cortex.Mediator;
using Cortex.Mediator.Infrastructure;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Events;
using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Domain.Services;
using Garmin.EB4368.U202318274.API.Shared.Domain.Exceptions;
using IUnitOfWork = Garmin.EB4368.U202318274.API.Shared.Domain.Repositories.IUnitOfWork;

namespace Garmin.EB4368.U202318274.API.Sales.Application.Internal.CommandServices;

public class QuoteRequestCommandService(
    IQuoteRequestRepository quoteRequestRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher
) : IQuoteRequestCommandService
{
    public async Task<QuoteRequest?> Handle(CreateQuoteRequestCommand command)
    {
        // General Exceptions
        if (command is null)
            throw new GeneralException("Command cannot be null", "VALIDATION_ERROR");

        if (command.Notes == null || command.Notes.Trim().Length == 0)
            throw new GeneralException("Notes cannot be null or empty", "VALIDATION_ERROR");

        if (command.StateId <= 0 || command.StateId > 4)
            throw new GeneralException("The State Id have to be Between 0 - 4", "VALIDATION_ERROR");

        if (command.RequestsUnits <= 0)
            throw new GeneralException("Requests Units have to be greater than 0", "VALIDATION_ERROR");


        // Validate only have to be one Quoterequest in Preparing state for one product Id
        var quoteRequest = new QuoteRequest(command);
        var quoteRequestId = quoteRequest.QuoteRequestId;
        var existQuoteRequestInPreparingState =
            await quoteRequestRepository.ExistByStateIdAndQuoteRequestIdAsync(command.StateId,
                quoteRequestId.Identifier);
        if (existQuoteRequestInPreparingState)
            throw new GeneralException("Quote request already exists with state Preparing", "ERROR");

        // Continue with creation if it does not exist
        await quoteRequestRepository.AddAsync(quoteRequest);
        await unitOfWork.CompleteAsync();
        await domainEventPublisher.PublishAsync(new QuoteResquestCreatedEvent(
            quoteRequest.RequestsUnits,
            command.StateId,
            quoteRequest.Notes
        ));

        return quoteRequest;
    }
}
using Cortex.Mediator.Commands;

namespace Garmin.EB4368.U202318274.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
public class LoggingCommandBehavior<TCommand> 
    : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(
        TCommand command, 
        CommandHandlerDelegate next,
        CancellationToken ct)
    {
        // Log before/after
        await next();
    }
}
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Aggregates;
using Garmin.EB4368.U202318274.API.Sales.Domain.Model.Commands;

namespace Garmin.EB4368.U202318274.API.Sales.Domain.Services;

public interface IQuoteRequestCommandService
{
    public Task<QuoteRequest?> Handle(CreateQuoteRequestCommand command);

}
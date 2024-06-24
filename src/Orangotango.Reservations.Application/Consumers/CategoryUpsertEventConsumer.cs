using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Core.Enums;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Consumers;

public class CategoryUpsertEventConsumer(ILoggerService _logger,
    ICategoryEventProcessor _categoryEventProcessor) : ConsumerBase<CategoryUpsertedEvent>
{
    public override async Task Consume(ConsumeContext<CategoryUpsertedEvent> context)
    {
        _logger.Information(nameof(OperationLogs.EventReceived), $"Evento recebido ({nameof(CategoryUpsertedEvent)}).", context.Message.TranceId);

        try
        {
            await _categoryEventProcessor.Upsert(context.Message);
        }
        catch (Exception ex)
        {
            _logger.Error(nameof(OperationLogs.EventProcessedWithFailure),
                $"Falha ao processar evento ({nameof(CategoryUpsertedEvent)}).",
                ex,
                context.Message.TranceId);

            throw;
        }
    }
}

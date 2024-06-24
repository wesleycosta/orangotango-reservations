using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Consumers;

public class CategoryUpsertEventConsumer(ILoggerService logger,
    ICategoryEventProcessor _categoryEventProcessor) : ConsumerBase<CategoryUpsertedEvent>(logger)
{
    public override async Task Consume(ConsumeContext<CategoryUpsertedEvent> context)
    {
        var @event = context.Message;

        try
        {
            LogInfoEventReceived(@event);
            await _categoryEventProcessor.Upsert(context.Message);
        }
        catch (Exception ex)
        {
            LogErrorProcessedWithFailure(@event, ex);
            throw;
        }
    }
}

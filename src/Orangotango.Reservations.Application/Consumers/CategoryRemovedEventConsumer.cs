using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Consumers;

public class CategoryRemovedEventConsumer(ILoggerService logger,
    ICategoryEventProcessor CategoryEventProcessor) : ConsumerBase<CategoryRemovedEvent>(nameof(CategoryRemovedEvent), logger)
{
    public override async Task Consume(ConsumeContext<CategoryRemovedEvent> context)
    {
        var @event = context.Message;

        try
        {
            LogInfoEventReceived(@event);
            await CategoryEventProcessor.Remove(@event.AggregateId);
        }
        catch (Exception ex)
        {
            LogErrorProcessedWithFailure(@event, ex);
            throw;
        }
    }
}

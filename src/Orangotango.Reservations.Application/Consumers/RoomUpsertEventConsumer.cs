using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Consumers;

public class RoomUpsertEventConsumer(ILoggerService logger,
    IRoomEventProcessor _roomEventProcessor) : ConsumerBase<RoomUpsertedEvent>(logger)
{
    public override async Task Consume(ConsumeContext<RoomUpsertedEvent> context)
    {
        var @event = context.Message;

        try
        {
            LogInfoEventReceived(@event);
            await _roomEventProcessor.Upsert(context.Message);
        }
        catch (Exception ex)
        {
            LogErrorProcessedWithFailure(@event, ex);
            throw;
        }
    }
}

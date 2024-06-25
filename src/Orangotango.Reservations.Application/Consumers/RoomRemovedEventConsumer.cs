using MassTransit;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;

namespace Orangotango.Reservations.Application.Consumers;

public class RoomRemovedEventConsumer(ILoggerService logger,
    IRoomEventProcessor _roomEventProcessor) : ConsumerBase<RoomRemovedEvent>(logger)
{
    public override async Task Consume(ConsumeContext<RoomRemovedEvent> context)
    {
        var @event = context.Message;

        try
        {
            LogInfoEventReceived(@event);
            await _roomEventProcessor.Remove(@event);
        }
        catch (Exception ex)
        {
            LogErrorProcessedWithFailure(@event, ex);
            throw;
        }
    }
}

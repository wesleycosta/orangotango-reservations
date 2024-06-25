using Orangotango.Events.Rooms.Category;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IRoomEventProcessor
{
    Task Upsert(RoomUpsertedEvent @event);
    Task Remove(RoomRemovedEvent @event);
}

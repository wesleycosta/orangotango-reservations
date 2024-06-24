using Orangotango.Events.Rooms.Category;

namespace Orangotango.Reservations.Application.Abstractions;

public interface ICategoryEventProcessor
{
    Task Upsert(CategoryUpsertedEvent @event);
}

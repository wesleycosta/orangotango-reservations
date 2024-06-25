using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Rooms.Aggregates;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Reservations.Application.Services;

internal sealed class RoomEventProcessor(ILoggerService logger,
    IUnitOfWork _unitOfWork,
    IRoomRepository _roomRepository) : EventProcessorBase(logger), IRoomEventProcessor
{

    public async Task Upsert(RoomUpsertedEvent @event)
    {
        var category = await _roomRepository.GetById(@event.AggregateId);
        Upsert(category, @event);

        await _unitOfWork.Commit();
        LogInfoEventProcessedSuccessfully(@event);
    }

    public async Task Remove(RoomRemovedEvent @event)
    {
        var category = await _roomRepository.GetById(@event.AggregateId);
        if (category is null)
        {
            return;
        }

        _roomRepository.SoftDelete(category);
        await _unitOfWork.Commit();
        LogInfoEventProcessedSuccessfully(@event);
    }

    private void Upsert(Room room, RoomUpsertedEvent @event)
    {
        if (room == null)
        {
            InsertRoom(@event);
            return;
        }

        UpdateRoom(room, @event);
    }

    private void InsertRoom(RoomUpsertedEvent @event)
    {
        var room = new Room(@event.AggregateId,
            @event.Name,
            @event.Number,
            @event.CategoryId);

        _roomRepository.Add(room);
    }

    private void UpdateRoom(Room room, RoomUpsertedEvent @event)
    {
        room.SetName(@event.Name)
            .SetNumber(@event.Number)
            .SetCategoryId(@event.CategoryId);

        _roomRepository.Update(room);
    }
}

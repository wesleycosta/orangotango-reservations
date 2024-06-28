using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Application.Mappers;

internal sealed class RoomMapper : IRoomMapper
{
    public RoomResult MapToResult(Room room)
        => new()
        {
            Id = room.Id,
            Name = room.Name
        };
}

using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IRoomMapper
{
    RoomResult MapToResult(Room room);
}

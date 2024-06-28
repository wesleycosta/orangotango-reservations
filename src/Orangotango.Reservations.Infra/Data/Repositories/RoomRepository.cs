using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Rooms;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Infra.Data.Repositories;

internal sealed class RoomRepository(ReservationsContext context) : RepositoryBaseWithRemoved<Room>(context), IRoomRepository
{
}

using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Rooms.Aggregates;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Reservations.Infra.Data.Repositories;

internal class RoomRepository(ReservationsContext context) : RepositoryBaseWithRemoved<Room>(context), IRoomRepository
{
}

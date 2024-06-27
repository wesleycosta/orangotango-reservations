using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Rooms;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Infra.Data.Repositories;

internal class CategoryRepository(ReservationsContext context) : RepositoryBaseWithRemoved<Category>(context), ICategoryRepository
{
}

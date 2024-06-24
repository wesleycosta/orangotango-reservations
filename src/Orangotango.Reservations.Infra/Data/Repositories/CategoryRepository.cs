using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Rooms.Aggregates;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Reservations.Infra.Data.Repositories;

internal class CategoryRepository(ReservationsContext context) : RepositoryBaseWithRemoved<Category>(context), ICategoryRepository
{
}

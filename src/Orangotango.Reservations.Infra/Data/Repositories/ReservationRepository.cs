using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Infra.Data.Repositories;

internal sealed class ReservationRepository(ReservationsContext context) : RepositoryBaseWithRemoved<Reservation>(context), IReservationRepository
{
}

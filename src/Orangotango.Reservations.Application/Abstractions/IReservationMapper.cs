using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IReservationMapper
{
    ReservationResult MapToReservationResult(Reservation reservation);
}

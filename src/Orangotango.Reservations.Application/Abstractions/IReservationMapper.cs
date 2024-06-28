using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IReservationMapper
{
    ReservationResult MapToResult(Reservation reservation);
    ReservationFullResult MapToFullResult(Reservation reservation);
}

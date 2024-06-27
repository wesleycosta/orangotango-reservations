using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Application.Services;

internal sealed class ReservationMapper : IReservationMapper
{
    public ReservationResult MapToReservationResult(Reservation reservation)
        => new()
        {
            Id = reservation.Id,
        };
}

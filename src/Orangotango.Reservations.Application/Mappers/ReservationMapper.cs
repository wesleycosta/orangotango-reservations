using Orangotango.Core.Extensions;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Application.Mappers;

internal sealed class ReservationMapper : IReservationMapper
{
    public ReservationResult MapToResult(Reservation reservation)
        => new()
        {
            Id = reservation.Id,
            GuestName = reservation.GuestName,
            GuestEmail = reservation.GuestEmail,
            CheckIn = reservation.CheckIn,
            CheckOut = reservation.CheckOut,
            Value = reservation.Value,
            Status = reservation.Status,
            Adults = reservation.Adults,
            Children = reservation.Children,
            RoomId = reservation.RoomId,
        };

    public ReservationFullResult MapToFullResult(Reservation reservation)
      => new()
      {
          Id = reservation.Id,
          GuestName = reservation.GuestName,
          GuestEmail = reservation.GuestEmail,
          CheckIn = reservation.CheckIn,
          CheckOut = reservation.CheckOut,
          Value = reservation.Value,
          Status = reservation.Status,
          Adults = reservation.Adults,
          Children = reservation.Children,
          RoomId = reservation.RoomId,
          RoomName = reservation.Room.Name,
          StatusName = reservation.Status.GetDescription()
      };
}

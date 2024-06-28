using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations.Entities;
using System.ComponentModel;
using System.Reflection;

namespace Orangotango.Reservations.Application.Services;

internal sealed class ReservationMapper : IReservationMapper
{
    public ReservationResult MapToReservationResult(Reservation reservation)
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

    public ReservationFullResult MapToReservationFullResult(Reservation reservation)
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

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field is null)
        {
            return default;
        }

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
}

using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Domain.Reservations.Entities;

public sealed class Reservation : EntityBase, IAggregateRoot
{
    public string GuestName { get; private set; }
    public string GuestEmail { get; private set; }
    public DateTimeOffset CheckIn { get; private set; }
    public DateTimeOffset CheckOut { get; private set; }
    public decimal Value { get; private set; }
    public int Adults { get; private set; }
    public int Children { get; private set; }
    public ReservationStatus Status { get; private set; }
    public Guid RoomId { get; private set; }
    public Room Room { get; private set; }

    public Reservation(string guestName,
        string guestEmail,
        DateTimeOffset checkIn,
        DateTimeOffset checkOut,
        decimal value,
        int adults,
        int children,
        Guid roomId)
    {
        GenerateId();
        GuestName = guestName;
        GuestEmail = guestEmail;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Value = value;
        Adults = adults;
        Children = children;
        Status = ReservationStatus.Booked;
        RoomId = roomId;
    }

    public Reservation SetGuestName(string guestName)
    {
        GuestName = guestName;
        return this;
    }

    public Reservation SetGuestEmail(string guestEmail)
    {
        GuestEmail = guestEmail;
        return this;
    }

    public Reservation SetCheckIn(DateTimeOffset checkIn)
    {
        CheckIn = checkIn;
        return this;
    }

    public Reservation SetCheckOut(DateTimeOffset checkOut)
    {
        CheckOut = checkOut;
        return this;
    }

    public Reservation SetValue(decimal value)
    {
        Value = value;
        return this;
    }

    public Reservation SetAdults(int adults)
    {
        Adults = adults;
        return this;
    }

    public Reservation SetChildren(int children)
    {
        Children = children;
        return this;
    }

    public Reservation SetStatus(ReservationStatus status)
    {
        Status = status;
        return this;
    }

    public Reservation SetRoomId(Guid roomId)
    {
        RoomId = roomId;
        return this;
    }
}

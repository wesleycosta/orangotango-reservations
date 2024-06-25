using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;
using Orangotango.Reservations.Domain.Reservations.ValueObjects;
using Orangotango.Reservations.Domain.Rooms.Aggregates;

namespace Orangotango.Reservations.Domain.Reservations.Entities;

public sealed class Reservation : EntityBase, IAggregateRoot
{
    //public Guest Guest { get; private set; }
    public StayPeriod Period { get; private set; }
    public decimal Value { get; private set; }
    public int Adults { get; private set; }
    public int Children { get; private set; }
    public ReservationStatus Status { get; private set; }
    public Guid RoomId { get; private set; }
    public Room Room { get; private set; }

    public bool HasDateChanged(StayPeriod period)
        => !Period.Equals(period);

    public bool IsItPossibleToCancel() =>
        Status == ReservationStatus.Booked;

    public bool IsItPossibleToCheckIn() =>
        Status == ReservationStatus.Booked;

    public bool IsItPossibleToCheckOut() =>
        Status == ReservationStatus.CheckIn;

    public void CheckIn()
    {
        if (!IsItPossibleToCheckIn())
            throw new DomainException("It is only possible to check in for bookings that have the same status as Booked");

        Status = ReservationStatus.CheckIn;
    }

    public void CheckOut()
    {
        if (!IsItPossibleToCheckOut())
            throw new DomainException("It is only possible to check out for bookings that have the same status as CheckIn");

        Status = ReservationStatus.CheckOut;
    }

    public void Cancel()
    {
        if (!IsItPossibleToCancel())
            throw new DomainException("It is only possible to cancel for bookings that have the same status as Booked");

        Status = ReservationStatus.Cancelled;
    }
}

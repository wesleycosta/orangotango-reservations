using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Reservations.Commands;

public abstract class ReservationCommandBase(string guestName,
    string guestEmail,
    Guid roomId,
    DateTimeOffset checkIn,
    DateTimeOffset checkOut,
    decimal value,
    int adults,
    int children) : CommandBase
{
    public string GuestName { get; private set; } = guestName;
    public string GuestEmail { get; private set; } = guestEmail;
    public Guid RoomId { get; private set; } = roomId;
    public DateTimeOffset CheckIn { get; private set; } = checkIn;
    public DateTimeOffset CheckOut { get; private set; } = checkOut;
    public decimal Value { get; private set; } = value;
    public int Adults { get; private set; } = adults;
    public int Children { get; private set; } = children;
}

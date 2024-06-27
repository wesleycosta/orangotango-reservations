namespace Orangotango.Reservations.Domain.Reservations.Commands;

public sealed class ReservationUpdateCommand(Guid id,
    string guestName,
    string guestEmail,
    Guid roomId,
    DateTimeOffset checkIn,
    DateTimeOffset checkOut,
    decimal value,
    int adults,
    int children) : ReservationCommandBase(guestName, guestEmail, roomId, checkIn, checkOut, value, adults, children)
{
    public Guid Id { get; private set; } = id;
}

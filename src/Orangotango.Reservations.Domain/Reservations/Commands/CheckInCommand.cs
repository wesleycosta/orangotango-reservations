namespace Orangotango.Reservations.Domain.Reservations.Commands;

public sealed class CheckInCommand(Guid id) : ReservationCommandWithIdBase(id)
{
}


namespace Orangotango.Reservations.Domain.Reservations.Commands;

public sealed class ReservationCancelCommand(Guid id) : ReservationCommandWithIdBase(id)
{
}

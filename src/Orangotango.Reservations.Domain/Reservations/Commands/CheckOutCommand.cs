namespace Orangotango.Reservations.Domain.Reservations.Commands;

public sealed class CheckOutCommand(Guid id) : ReservationCommandWithIdBase(id)
{
}

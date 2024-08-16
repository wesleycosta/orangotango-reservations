using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Reservations.Commands;

public abstract class ReservationCommandWithIdBase(Guid id) : CommandBase
{
    public Guid Id { get; private set; } = id;
}

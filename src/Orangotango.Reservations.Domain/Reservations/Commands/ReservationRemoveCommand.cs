using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Reservations.Commands;

public sealed class ReservationRemoveCommand(Guid id) : CommandBase
{
    public Guid Id { get; private set; } = id;
}

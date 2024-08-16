using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class ReservationRemoveCommandValidator(IReservationRepository resevationRepository)
    : ReservationCommandWithIdValidatorBase<ReservationRemoveCommand>(resevationRepository)
{
}

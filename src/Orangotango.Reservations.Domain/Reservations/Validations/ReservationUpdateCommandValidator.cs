using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class ReservationUpdateCommandValidator : ReservationCommandValidatorBase<ReservationUpdateCommand>
{
    public ReservationUpdateCommandValidator(IReservationRepository resevationRepository) : base(resevationRepository)
    {
    }
}

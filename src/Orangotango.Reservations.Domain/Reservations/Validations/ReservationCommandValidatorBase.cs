using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public abstract class ReservationCommandValidatorBase<TCommand> : ValidatorBase<TCommand> where TCommand : ReservationCommandBase
{
    protected readonly IReservationRepository _reservationRepository;

    protected ReservationCommandValidatorBase(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
        ValidateName();
    }

    protected void ValidateName()
    {
        RuleFor(command => command.GuestName)
          .NotNull()
          .NotEmpty()
          .WithMessage(ValidatorMessages.NotInformed(nameof(ReservationCreateCommand.GuestName)));

        RuleFor(command => command.GuestName)
           .MaximumLength(MAX_LENGTH_STRING)
           .WithMessage(ValidatorMessages.LessThanString(nameof(ReservationCreateCommand.GuestName)));
    }
}

using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public abstract class ReservationCommandWithIdValidatorBase<TCommand> : ValidatorBase<TCommand> where TCommand : ReservationCommandWithIdBase
{
    protected readonly IReservationRepository ReserationRepository;

    public ReservationCommandWithIdValidatorBase(IReservationRepository resevationRepository)
    {
        ReserationRepository = resevationRepository;
        ValidateIfExists();
    }

    private void ValidateIfExists()
        => RuleFor(command => command.Id)
        .CustomAsync(async (id, context, cancellationToken) =>
        {
            var categoryExists = await ReserationRepository.Any(p => p.Id == id);
            if (!categoryExists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Reservation)));
            }
        });
}

using FluentValidation;
using Orangotango.Core.Domain.Validations;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Rooms.Domain.Categories.Validations;

public sealed class ReservationRemoveCommandValidator : ValidatorBase<ReservationRemoveCommand>
{
    private readonly IReservationRepository _reserationRepository;

    public ReservationRemoveCommandValidator(IReservationRepository resevationRepository)
    {
        _reserationRepository = resevationRepository;

        ValidateIfExists();
    }

    private void ValidateIfExists()
        => RuleFor(command => command.Id)
        .CustomAsync(async (id, context, cancellationToken) =>
        {
            var categoryExists = await _reserationRepository.Any(p => p.Id == id);
            if (!categoryExists)
            {
                context.AddFailure(ValidatorMessages.NotFound(nameof(Reservation)));
            }
        });
}

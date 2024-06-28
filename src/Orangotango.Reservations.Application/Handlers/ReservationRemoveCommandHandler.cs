using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Reservations.Application.Handlers;

internal sealed class ReservationRemoveCommandHandler(IUnitOfWork unitOfWork,
    IValidator<ReservationRemoveCommand> validator,
    IReservationMapper _mapper,
    IReservationRepository _repository,
    IReservationPublisher _publisher) : CommandHandlerBase<ReservationRemoveCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(ReservationRemoveCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var reservation = await _repository.GetById(command.Id);
        _repository.SoftDelete(reservation);

        if (await Commit())
        {
            // TODO
            //await _publisher.Publish(reservation.GenerateRemovedEvent());

            return SuccessfulResult(_mapper.MapToResult(reservation));
        }

        return BadResult();
    }
}

using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Reservations.Application.Handlers;

internal sealed class ReservationCancelCommandHandler(IUnitOfWork unitOfWork,
    IValidator<ReservationCancelCommand> validator,
    IReservationMapper _mapper,
    IReservationRepository _repository,
    IReservationPublisher _publisher) : CommandHandlerBase<ReservationCancelCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(ReservationCancelCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var reservation = await _repository.GetById(command.Id);
        reservation.ExecuteCancel();
        _repository.Update(reservation);

        if (await Commit())
        {
            // TODO
            //await _publisher.Publish(Reservation.GenerateUpsertedEvent());
            return SuccessfulResult(_mapper.MapToResult(reservation));
        }

        return BadResult();
    }
}

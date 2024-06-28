using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Application.Handlers;

internal sealed class ReservationCreateCommandHandler(IUnitOfWork _unitOfWork,
    IValidator<ReservationCreateCommand> _validator,
    IReservationMapper _mapper,
    IReservationRepository _repository,
    IReservationPublisher _publisher) : CommandHandlerBase<ReservationCreateCommand>(_unitOfWork, _validator)
{
    public override async Task<Result> Handle(ReservationCreateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var reservation = new Reservation(command.GuestName,
            command.GuestEmail,
            command.CheckIn,
            command.CheckOut,
            command.Value,
            command.Adults,
            command.Children,
            command.RoomId);

        _repository.Add(reservation);

        if (await Commit())
        {
            //await _publisher.Publish(reservation.GenerateUpsertedEvent());
            // TODO: arrumar

            return SuccessfulResult(_mapper.MapToResult(reservation));
        }

        return BadResult();
    }
}

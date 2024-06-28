using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Reservations.Application.Handlers;

internal sealed class ReservationUpdateCommandHandler(IUnitOfWork unitOfWork,
    IValidator<ReservationUpdateCommand> validator,
    IReservationMapper _mapper,
    IReservationRepository _repository,
    IReservationPublisher _publisher) : CommandHandlerBase<ReservationUpdateCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(ReservationUpdateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var reservation = await _repository.GetById(command.Id);
        reservation.SetGuestName(command.GuestName)
            .SetGuestEmail(command.GuestEmail)
            .SetCheckIn(command.CheckIn)
            .SetCheckOut(command.CheckOut)
            .SetValue(command.Value)
            .SetAdults(command.Adults)
            .SetChildren(command.Children)
            .SetRoomId(command.RoomId);

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

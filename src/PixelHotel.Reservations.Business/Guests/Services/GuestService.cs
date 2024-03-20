using FluentValidation;
using PixelHotel.Core.Data;
using PixelHotel.Core.Domain.Services;
using PixelHotel.Events.Guests;
using PixelHotel.Reservations.Business.Guests.Abstractions;
using PixelHotel.Reservations.Business.Guests.Aggregates;
using PixelHotel.Reservations.Business.Guests.Commands;

namespace PixelHotel.Reservations.Business.Guests.Services;

internal class GuestService : ServiceBase, IGuestService
{
    private readonly IGuestRepository _guestRepository;
    protected readonly IValidator<GuestCreateCommand> _validator;

    public GuestService(IUnitOfWork unitOfWork,
        IGuestRepository guestRepository,
        IValidator<GuestCreateCommand> validator) : base(unitOfWork)
    {
        _guestRepository = guestRepository;
        _validator = validator;
    }

    public async Task<Result> Create(GuestCreateCommand command)
    {
        if (!await Validate(_validator, command))
        {
            return BadCommand();
        }

        var guest = new Guest(command.Name,
            command.Email,
            command.DateOfBirth);

        var @event = new GuestCreatedOrUpdatedEvent(guest.Id,
            guest.Name,
            guest.Email.Address,
            guest.DateOfBirth.Date);

        guest.AddEvent(@event);
        _guestRepository.Add(guest);

        return await SaveData(guest);
    }
}

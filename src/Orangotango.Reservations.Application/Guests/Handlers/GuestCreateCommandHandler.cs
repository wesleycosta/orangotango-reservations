//using FluentValidation;
//using Orangotango.Core.Abstractions;
//using Orangotango.Core.Services;
//using Orangotango.Events.Guests;
//using Orangotango.Reservations.Business.Guests.Abstractions;
//using Orangotango.Reservations.Business.Guests.Aggregates;
//using Orangotango.Reservations.Business.Guests.Commands;

//namespace Orangotango.Reservations.Application.Guests.Handlers;

//public class GuestCreateCommandHandler : CommandHandlerBase<GuestCreateCommand>
//{
//    private readonly IGuestRepository _guestRepository;
//    protected readonly IValidator<GuestCreateCommand> _validator;

//    public GuestCreateCommandHandler(IUnitOfWork unitOfWork,
//        IGuestRepository guestRepository,
//        IValidator<GuestCreateCommand> validator) : base(unitOfWork)
//    {
//        _guestRepository = guestRepository;
//        _validator = validator;
//    }

//    public override async Task<Result> Handle(GuestCreateCommand request, CancellationToken cancellationToken)
//    {
//        if (!await Validate(_validator, request))
//            return BadCommand();

//        var guest = new Guest(request.FirstName,
//            request.LastName,
//            request.Email,
//            request.DateOfBirth);

//        var @event = new GuestCreatedOrUpdatedEvent(guest.Id,
//            guest.FirstName,
//            guest.LastName,
//            guest.Email.Address,
//            guest.DateOfBirth.Date);

//        guest.AddEvent(@event);
//        _guestRepository.Add(guest);

//        return await SaveChanges(guest);
//    }
//}

// TODO

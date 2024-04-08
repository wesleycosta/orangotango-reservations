//using FluentValidation;
//using PixelHotel.Core.Domain.Validations;
//using PixelHotel.Reservations.Business.Guests.Aggregates;
//using PixelHotel.Reservations.Business.Guests.Commands;

//namespace PixelHotel.Reservations.Business.Guests.Validations;

//public class GuestCreateCommandValidation : AbstractValidator<GuestCreateCommand>
//{
//    public GuestCreateCommandValidation()
//    {
//        RuleFor(command => command.FirstName)
//           .NotNull()
//           .NotEmpty()
//           .WithMessage(ValidationMessages.NotInformed(nameof(GuestCreateCommand.FirstName)));

//        RuleFor(command => command.FirstName)
//            .NotNull()
//            .NotEmpty()
//            .WithMessage(ValidationMessages.NotInformed(nameof(GuestCreateCommand.LastName)));

//        RuleFor(command => command.Email)
//            .NotNull()
//            .NotEmpty()
//            .EmailAddress()
//            .WithMessage(ValidationMessages.IsInvalid(nameof(GuestCreateCommand.Email)));

//        RuleFor(command => command.DateOfBirth)
//            .NotEmpty()
//            .NotNull()
//            .WithMessage(ValidationMessages.NotInformed(nameof(GuestCreateCommand.DateOfBirth)));

//        RuleFor(command => command.DateOfBirth)
//            .Must(DateOfBirth.IsValid)
//            .WithMessage(ValidationMessages.IsInvalid(nameof(GuestCreateCommand.DateOfBirth)));
//    }
//}


// TODO

using PixelHotel.Core.Domain;
using PixelHotel.Core.Domain.Abstractions;

namespace PixelHotel.Reservations.Business.Guests.Aggregates;

internal sealed class Guest : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }

    public Guest(string name,
        string emailAddress,
        DateOnly dateOfBirth)
    {
        GenerateId();
        Name = name;
        Email = new Email(emailAddress);
        DateOfBirth = new DateOfBirth(dateOfBirth);
    }
}

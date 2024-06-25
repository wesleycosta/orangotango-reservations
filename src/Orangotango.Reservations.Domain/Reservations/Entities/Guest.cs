using Orangotango.Reservations.Domain.Reservations.ValueObjects;

namespace Orangotango.Reservations.Domain.Reservations.Aggregates;

public sealed class Guest
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }

    public Guest(string name,
        string lastName,
        string emailAddress)
    {
        FirstName = name;
        LastName = lastName;
        Email = new Email(emailAddress);
    }
}

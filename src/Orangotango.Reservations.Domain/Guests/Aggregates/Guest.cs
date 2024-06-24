namespace Orangotango.Reservations.Domain.Guests.Aggregates;

public class Guest
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }

    public Guest(string name,
        string lastName,
        string emailAddress,
        DateOnly dateOfBirth)
    {
        FirstName = name;
        LastName = lastName;
        Email = new Email(emailAddress);
        DateOfBirth = new DateOfBirth(dateOfBirth);
    }
}

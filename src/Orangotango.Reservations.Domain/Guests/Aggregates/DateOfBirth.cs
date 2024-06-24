using Orangotango.Core.Abstractions;
using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Guests.Aggregates;

public sealed class DateOfBirth : IValueObject
{
    public static readonly DateOnly MinValue = DateOnly.FromDateTime(new DateTime(1990, 01, 01));

    public DateOnly Date { get; private set; }

    public DateOfBirth(DateOnly birthday)
    {
        if (!IsValid(birthday))
            throw new DomainException("Birthday is invalid");

        Date = birthday;
    }

    public static bool IsValid(DateOnly birthday)
        => birthday > MinValue;

    public override string ToString()
        => Date.ToString();
}

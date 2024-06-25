using Orangotango.Core.Domain;

namespace Orangotango.Reservations.Domain.Reservations.ValueObjects;

public sealed class StayPeriod
{
    public static readonly DateTimeOffset MinValue = new(new DateTime(2010, 01, 01), TimeSpan.Zero);
    public DateTimeOffset CheckIn { get; private set; }
    public DateTimeOffset CheckOut { get; private set; }

#pragma warning disable CS0628 // EF
    protected StayPeriod() { }

    public StayPeriod(DateTimeOffset checkIn, DateTimeOffset checkOut)
    {
        if (!IsValidDate(checkIn))
            throw new DomainException("CheckInDate is invalid");

        if (!IsValidDate(checkOut))
            throw new DomainException("CheckOutDate is invalid");

        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public static bool IsValid(DateTimeOffset checkIn, DateTimeOffset checkOut) =>
        IsValidDate(checkIn) && IsValidDate(checkOut);

    private static bool IsValidDate(DateTimeOffset date) =>
        date > MinValue;

    public override bool Equals(object obj)
    {
        if (obj is not StayPeriod date)
            return false;

        return CheckIn.Date.Equals(date.CheckIn.Date) && CheckOut.Date.Equals(date.CheckOut.Date);
    }

    public override string ToString() =>
        $"{CheckIn.Date:dd/MM/yyyy} of {CheckOut.Date:dd/MM/yyyy}";

    public override int GetHashCode() =>
          (GetType().GetHashCode() * 907) + CheckIn.GetHashCode() + CheckOut.GetHashCode();
}

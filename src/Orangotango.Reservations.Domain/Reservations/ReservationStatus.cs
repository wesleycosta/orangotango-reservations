using System.ComponentModel;

namespace Orangotango.Reservations.Domain.Reservations;

public enum ReservationStatus
{
    [Description("Cancelled")]
    Cancelled,
    
    [Description("Booked")]
    Booked,

    [Description("Check-In")]
    CheckIn,

    [Description("Check-Out")]
    CheckOut
}

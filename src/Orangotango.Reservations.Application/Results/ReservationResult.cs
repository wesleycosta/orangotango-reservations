using Orangotango.Core.Results;
using Orangotango.Reservations.Domain.Reservations;

namespace Orangotango.Reservations.Application.Results;

public class ReservationResult : ResultBase
{
    public string GuestName { get; set; }
    public string GuestEmail { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }
    public decimal Value { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public ReservationStatus Status { get; set; }
    public Guid RoomId { get; set; }
}

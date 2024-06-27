namespace Orangotango.Reservations.Api.InputModels;

public class ReservationUpsertInputModel
{
    public string GuestName { get; set; }
    public string GuestEmail { get; set; }
    public Guid RoomId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }
    public decimal Value { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
}

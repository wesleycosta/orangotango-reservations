namespace PixelHotel.Reservations.Application.Guests.Contracts;

public class GuestResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
}

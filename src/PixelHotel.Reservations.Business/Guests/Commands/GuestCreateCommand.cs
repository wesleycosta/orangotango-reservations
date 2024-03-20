namespace PixelHotel.Reservations.Business.Guests.Commands;

public class GuestCreateCommand
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required DateOnly DateOfBirth { get; init; }
}

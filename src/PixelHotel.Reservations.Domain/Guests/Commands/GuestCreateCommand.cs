namespace PixelHotel.Reservations.Business.Guests.Commands;

public class GuestCreateCommand 
    //: Command // TODO
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required DateOnly DateOfBirth { get; init; }
}

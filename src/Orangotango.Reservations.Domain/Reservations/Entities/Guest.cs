namespace Orangotango.Reservations.Domain.Reservations.Entities;

public sealed class Guest
{
    public string Name { get; set; }
    public string Email { get; set; }

    protected Guest() { }
}

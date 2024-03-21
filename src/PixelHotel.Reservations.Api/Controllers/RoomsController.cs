using Microsoft.AspNetCore.Mvc;
using PixelHotel.Reservations.Application.Guests.Abstractions;
using PixelHotel.Reservations.Business.Guests.Commands;

namespace PixelHotel.Reservations.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IGuestService _guestService;

    public RoomsController(IGuestService guestService)
        => _guestService = guestService;

    [HttpGet]
    public IActionResult GetOk()
    {
        var command = new GuestCreateCommand
        {
            Name = "Wesley",
            Email = "wesley.costa@mail.com",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1996, 10, 28))
        };

        var result = _guestService.Create(command);
        return Ok(result);
    }
}

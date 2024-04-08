using Microsoft.AspNetCore.Mvc;
using PixelHotel.Api;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Reservations.Business.Guests.Commands;

namespace PixelHotel.Reservations.Api.Controllers;

[ApiController]
[Route("api/guests")]
public class GuestsController(IMediatorHandler _mediatorHandler) : MainController
{
    [HttpGet]
    public async Task<IActionResult> GetOk()
    {
        var command = new GuestCreateCommand
        {
            FirstName = "Wesley",
            LastName = "Costa",
            Email = "wesley.costa@mail.com",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1996, 10, 28, 0, 0, 0, DateTimeKind.Utc))
        };

        //var result = await _mediatorHandler.SendCommand(command);
        // TODO
        return Ok();
    }
}

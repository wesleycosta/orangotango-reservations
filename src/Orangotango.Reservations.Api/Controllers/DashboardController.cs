using Microsoft.AspNetCore.Mvc;
using Orangotango.Api;

namespace Orangotango.Reservations.Api.Controllers;

[Route("api/dashboard")]
public class DashboardController : MainController
{

    [HttpGet]
    public async Task<IActionResult> GetDashboard()
    {
        await Task.CompletedTask;
        return Ok();
    }
}

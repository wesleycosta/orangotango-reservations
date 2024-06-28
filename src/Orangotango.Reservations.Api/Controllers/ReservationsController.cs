using Microsoft.AspNetCore.Mvc;
using Orangotango.Api;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Reservations.Api.InputModels;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Reservations.Api.Controllers;

[Route("api/reservations")]
public sealed class CategoriesController(IMediatorHandler _mediator,
    IReservationQueryService _queryService,
    IRoomQueryService _roomQueryService) : MainController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReservationUpsertInputModel inputModel)
    {
        var command = new ReservationCreateCommand(inputModel.GuestName,
            inputModel.GuestEmail,
            inputModel.RoomId,
            inputModel.CheckIn,
            inputModel.CheckOut,
            inputModel.Value,
            inputModel.Adults,
            inputModel.Children);

        var result = await _mediator.SendCommand(command);
        return Created("~/api/reservations", result);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ReservationUpsertInputModel inputModel)
    {
        var command = new ReservationUpdateCommand(id, inputModel.GuestName,
            inputModel.GuestEmail,
            inputModel.RoomId,
            inputModel.CheckIn,
            inputModel.CheckOut,
            inputModel.Value,
            inputModel.Adults,
            inputModel.Children);

        var result = await _mediator.SendCommand(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new ReservationRemoveCommand(id);
        var result = await _mediator.SendCommand(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _queryService.GetById(id);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string searchValue)
    {
        var result = await _queryService.Search(searchValue);
        return Ok(result);
    }

    [HttpGet("rooms")]
    public async Task<IActionResult> GetRooms([FromQuery] Guid? reservationId)
    {
        var result = await _roomQueryService.GetAll(reservationId);
        return Ok(result);
    }
}

using GerenciadorHotel.Application.Interfaces.Calendary.Commands.GenerateCalendaryForRoom;
using GerenciadorHotel.Application.Interfaces.Calendary.Queries.GetCalendaryByRoomId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/calendars")]
public class CalendarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalendarsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateCalendaryForRoom(int idRoom, DateTime startDate, DateTime endDate, int idAdmin)
    {
        if (startDate > endDate)
            return BadRequest("A data de início não pode ser maior que a data de término.");
        

        var result = await _mediator.Send(new GenerateCalendaryForRoomCommand(idRoom, startDate, endDate, idAdmin));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok("Calendário gerado com sucesso.");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCalendary(int roomId)
    {
        var result = await _mediator.Send(new GetCalendaryByRoomIdQuery(roomId));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result.Data);
    }
}
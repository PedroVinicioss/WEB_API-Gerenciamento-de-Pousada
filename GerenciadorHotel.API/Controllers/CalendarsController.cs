using GerenciadorHotel.Application.Interfaces.Calendary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/calendars")]
public class CalendarsController : ControllerBase
{
    private readonly ICalendaryService _calendaryService;

    public CalendarsController(ICalendaryService calendaryService)
    {
        _calendaryService = calendaryService;
    }
    
    [HttpPost("generate")]
    public IActionResult GenerateCalendaryForRoom(int roomId, DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            return BadRequest("A data de início não pode ser maior que a data de término.");
        }

        _calendaryService.GenerateCalendaryForRoom(roomId, startDate, endDate);
        return Ok("Calendário gerado com sucesso.");
    }
    
    [HttpGet]
    public IActionResult GetCalendary(int roomId)
    {
        var calendary = _calendaryService.GetCalendaryForRoom(roomId);
        return Ok(calendary);
    }
}
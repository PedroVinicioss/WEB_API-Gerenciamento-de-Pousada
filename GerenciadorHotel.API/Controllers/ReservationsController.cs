using GerenciadorHotel.Application.Interfaces.Reservation.Commands.CreateReservation;
using GerenciadorHotel.Application.Interfaces.Reservation.Commands.DeleteReservation;
using GerenciadorHotel.Application.Interfaces.Reservation.Commands.UpdateReservation;
using GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetAllReservations;
using GerenciadorHotel.Application.Interfaces.Reservation.Queries.GetReservationsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search = "")
    {
        var results = await _mediator.Send(new GetAllReservationsQuery(search));
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetReservationsByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateReservationCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    // PUT
    [HttpPut]
    public async Task<IActionResult> Put(UpdateReservationCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteReservationCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
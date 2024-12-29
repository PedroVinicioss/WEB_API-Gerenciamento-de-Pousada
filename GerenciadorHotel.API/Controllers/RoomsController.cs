using GerenciadorHotel.Application.Interfaces.Room.Commands.CreateRoom;
using GerenciadorHotel.Application.Interfaces.Room.Commands.DeleteRoom;
using GerenciadorHotel.Application.Interfaces.Room.Queries.GetAllRooms;
using GerenciadorHotel.Application.Interfaces.Room.Queries.GetRoomById;
using GerenciadorHotel.Application.Interfaces.User.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search = "")
    {
        var results = await _mediator.Send(new GetAllRoomsQuery(search));
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetRoomByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateRoomCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    // PUT
    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserCommand command)
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
        var result = await _mediator.Send(new DeleteRoomCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
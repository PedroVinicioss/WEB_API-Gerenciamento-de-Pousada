using GerenciadorHotel.Application.Interfaces.User.Commands.CreateUser;
using GerenciadorHotel.Application.Interfaces.User.Commands.DeleteUser;
using GerenciadorHotel.Application.Interfaces.User.Commands.UpdateUser;
using GerenciadorHotel.Application.Interfaces.User.Queries.GetAllUsers;
using GerenciadorHotel.Application.Interfaces.User.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController( IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search = "")
    {
        var results = await _mediator.Send(new GetAllUsersQuery(search));
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        //var result = _userService.Insert(model);
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
        //var result = _userService.Delete(id);
        var result = await _mediator.Send(new DeleteUserCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
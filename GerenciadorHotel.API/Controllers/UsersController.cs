using GerenciadorHotel.Application.Interfaces.User.Commands.CreateUser;
using GerenciadorHotel.Application.Interfaces.User.Commands.DeleteUser;
using GerenciadorHotel.Application.Interfaces.User.Services;
using GerenciadorHotel.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    IUserService _userService;
    private IMediator _mediator;
    public UsersController(IUserService service, IMediator mediator)
    {
        _userService = service;
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        var results = _userService.GetAll();
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _userService.GetById(id);
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
    public IActionResult Put(User model)
    {
        var result = _userService.Update(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteUserCommand command)
    {
        //var result = _userService.Delete(id);
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
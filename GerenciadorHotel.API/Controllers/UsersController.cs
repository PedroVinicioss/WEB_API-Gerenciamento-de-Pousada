using GerenciadorHotel.Application.Interfaces.User.Services;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    IUserService _userService;
    public UsersController(IUserService service)
    {
        _userService = service;
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
    public IActionResult Post(CreateUserInputModel model)
    {
        var result = _userService.Insert(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
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
    public IActionResult Delete(int id)
    {
        var result = _userService.Delete(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
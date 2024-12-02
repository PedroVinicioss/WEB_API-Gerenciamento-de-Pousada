using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Models.ViewModels;
using GerenciadorHotel.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    IUserService _service;
    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        var results = _service.GetAll();
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var result = _service.Insert(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }
    
    // PUT
    [HttpPut]
    public IActionResult Put(UpdateUserInputModel model)
    {
        var result = _service.Update(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
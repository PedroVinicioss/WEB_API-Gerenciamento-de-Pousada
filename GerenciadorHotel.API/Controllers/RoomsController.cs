using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Services;
using GerenciadorHotel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    IRoomService _roomService;
    
    public RoomsController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll(string search = "")
    {
        var results = _roomService.GetAll(search);
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _roomService.GetById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post(CreateRoomInputModel model)
    {
        var result = _roomService.Insert(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }
    
    // PUT
    [HttpPut]
    public IActionResult Put(Room model)
    {
        var result = _roomService.Update(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _roomService.Delete(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
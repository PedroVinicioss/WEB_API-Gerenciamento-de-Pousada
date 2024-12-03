using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Services;
using GerenciadorHotel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private IReservationService _reservationService;
    
    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        var results = _reservationService.GetAll();
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _reservationService.GetById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post(CreateReservationInputModel model)
    {
        var result = _reservationService.Insert(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }
    
    // PUT
    [HttpPut]
    public IActionResult Put(Reservation model)
    {
        var result = _reservationService.Update(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _reservationService.Delete(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
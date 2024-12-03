using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Application.Services;
using GerenciadorHotel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/consumptions")]
public class ConsumptionsController : ControllerBase
{
    IConsumptionService _consumptionService;
    
    public ConsumptionsController(IConsumptionService service)
    {
        _consumptionService = service;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _consumptionService.GetAll();
        return Ok(result);
    }

    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _consumptionService.GetById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post(CreateConsumptionInputModel model)
    {
        var result = _consumptionService.Insert(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }
    
    // PUT
    [HttpPut]
    public IActionResult Put(Consumption model)
    {
        var result = _consumptionService.Update(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _consumptionService.Delete(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
﻿using GerenciadorHotel.Application.Interfaces.Consumption.Commands.CreateConsumption;
using GerenciadorHotel.Application.Interfaces.Consumption.Commands.DeleteConsumption;
using GerenciadorHotel.Application.Interfaces.Consumption.Commands.UpdateConsumption;
using GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetAllConsumptions;
using GerenciadorHotel.Application.Interfaces.Consumption.Queries.GetConsumptionsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/consumptions")]
public class ConsumptionsController : ControllerBase
{
    private IMediator _mediator;
    
    public ConsumptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search)
    {
        var result = await _mediator.Send(new GetAllConsumptionsQuery(search));
        return Ok(result);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetConsumptionsByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateConsumptionCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    // PUT
    [HttpPut]
    public async Task<IActionResult> Put(UpdateConsumptionCommand command)
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
        var result = await _mediator.Send(new DeleteConsumptionCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
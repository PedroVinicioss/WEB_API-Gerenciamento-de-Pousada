﻿using GerenciadorHotel.Application.Interfaces.Customers.Commands.CreateCustomer;
using GerenciadorHotel.Application.Interfaces.Customers.Commands.DeleteCustomer;
using GerenciadorHotel.Application.Interfaces.Customers.Commands.UpdateCustomer;
using GerenciadorHotel.Application.Interfaces.Customers.Queries.GetAllCustomers;
using GerenciadorHotel.Application.Interfaces.Customers.Queries.GetCustomerById;
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
        var results = await _mediator.Send(new GetAllCustomersQuery(search));
        return Ok(results);
    }
    
    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand command)
    {
        //var result = _userService.Insert(model);
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    // PUT
    [HttpPut]
    public async Task<IActionResult> Put(UpdateCustomerCommand command)
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
        var result = await _mediator.Send(new DeleteCustomerCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
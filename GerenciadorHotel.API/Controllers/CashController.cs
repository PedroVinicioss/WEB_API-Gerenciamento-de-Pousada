using GerenciadorHotel.Application.Interfaces.Cash.Commands.DeleteCash;
using GerenciadorHotel.Application.Interfaces.Cash.Commands.UpdateCash;
using GerenciadorHotel.Application.Interfaces.Cash.Queries.GetAllCash;
using GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/cash")]
public class CashController : Controller
{
    private IMediator _mediator;
    
    public CashController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search = "")
    {
        var result = await _mediator.Send(new GetAllCashQuery(search));
        return Ok(result);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCashByIdQuery(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateCashCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCashCommand(id));
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
}
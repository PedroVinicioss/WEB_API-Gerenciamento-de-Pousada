using GerenciadorHotel.Application.Interfaces.Product.Commands.CreateProduct;
using GerenciadorHotel.Application.Interfaces.Product.Commands.DeleteProduct;
using GerenciadorHotel.Application.Interfaces.Product.Commands.UpdateProduct;
using GerenciadorHotel.Application.Interfaces.Product.Queries.GetAllProducts;
using GerenciadorHotel.Application.Interfaces.Product.Queries.GetProductsById;
using GerenciadorHotel.Application.Interfaces.Product.Services;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private IMediator _mediator;
    
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAll(string search = "")
    {
        var results = await _mediator.Send(new GetAllProductsQuery(search));
        return Ok(results);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductsById(id));
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }
    
    // PUT
    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
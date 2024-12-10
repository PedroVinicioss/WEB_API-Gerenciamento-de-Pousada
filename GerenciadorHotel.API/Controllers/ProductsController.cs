using GerenciadorHotel.Application.Interfaces.Product.Services;
using GerenciadorHotel.Application.Models.InputModels;
using GerenciadorHotel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    IProductService _productService;
    
    public ProductsController(IProductService service)
    {
        _productService = service;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll(string search = "")
    {
        var results = _productService.GetAll(search);
        return Ok(results);
    }

    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post(CreateProductInputModel model)
    {
        var result = _productService.Insert(model);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }
    
    // PUT
    [HttpPut]
    public IActionResult Put(Product model)
    {
        var result = _productService.Update(model);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _productService.Delete(id);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return NoContent();
    }
}
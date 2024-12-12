using GerenciadorHotel.Application.Interfaces.Cash.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/cash")]
public class CashController : Controller
{
    private ICashService _cashService;
    
    public CashController(ICashService cashService)
    {
        _cashService = cashService;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll(string search = "")
    {
        var result = _cashService.GetAll(search);
        return Ok(result);
    }

    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _cashService.GetById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
    
    // PUT
    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        return Ok();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}
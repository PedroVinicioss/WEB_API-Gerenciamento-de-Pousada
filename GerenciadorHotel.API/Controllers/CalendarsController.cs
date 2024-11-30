using GerenciadorHotel.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/calendars")]
public class CalendarsController : ControllerBase
{
    private readonly AppDbContext _context;

    public CalendarsController(AppDbContext context)
    {
        _context = context;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        var calendars = _context.Calendars.Where(p => !p.IsDeleted).ToList();
        return Ok(calendars);
    }

    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var calendar = _context.Calendars.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        if (calendar is null) { return NotFound(); }
        
        return Ok(calendar);
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
﻿using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.Controllers;

[ApiController]
[Route("api/cash")]
public class CashController : Controller
{
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    // GET
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
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
using System.ComponentModel.DataAnnotations;
using GerenciadorHotel.Application.Interfaces.Authentication.Services;
using GerenciadorHotel.Application.Interfaces.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHotel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IUserService _userService;

    public AuthController(JwtService jwtService , IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _userService.Authenticate(request.Email, request.Senha);
        if (!result.IsSuccess)
            return Unauthorized(result.Message);
        
        var token = _jwtService.GenerateToken(result.Data.ToString(), request.Email);
        return Ok(token);
    }
}

public class LoginRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}
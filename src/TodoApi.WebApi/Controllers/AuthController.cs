using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Abstractions;
using TodoApi.Application.DTOs;

namespace TodoApi.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IJwtTokenGenerator tokenGenerator) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Demo auth. Replace with real identity provider/user store.
        var userId = request.Email.ToLowerInvariant();
        var token = tokenGenerator.Generate(userId, request.Email);
        return Ok(new AuthResponse(token));
    }
}

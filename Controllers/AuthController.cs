using System.Security.Claims;
using CarWorkshopAPI.Commands.Login;
using CarWorkshopAPI.Commands.Register;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Models;
using CarWorkshopAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator _mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _mediator.Send(new RegisterCommand(dto));
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginDto dto)
    {
        var token = await _mediator.Send(new LoginCommand(dto));
        if (token == null) return Unauthorized();
        
        return Ok(new { token });
    }
    
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(new
        {
            Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Username = User.Identity?.Name,
            Role = User.FindFirstValue(ClaimTypes.Role)
        });
    }
}
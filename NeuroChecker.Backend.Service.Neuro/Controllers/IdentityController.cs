using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Controllers;

[ApiController, Route("api/identity")]
public class IdentityController(IIdentityService identityService) : ControllerBase
{
    [HttpGet("me"), Authorize]
    public async Task<IActionResult> GetMe()
    {
        var userDto = await identityService.GetMeUserAsync(User);
        return userDto is null ? Unauthorized() : Ok(userDto);
    }

    [HttpPost("register"), AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var dto = request.ToRegisterDto();
        var result = await identityService.RegisterUserAsync(dto);
        if (result) return Ok(new { Message = "User registered successfully." });

        return BadRequest(new { Message = "User registration failed." });
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var dto = request.ToLoginDto();
        var result = await identityService.LoginUserAsync(dto);
        if (result) return Ok(new { Message = "User logged in successfully." });

        return Unauthorized(new { Message = "Invalid email or password." });
    }
}
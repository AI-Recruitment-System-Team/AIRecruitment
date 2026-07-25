using AIRecruitment.BLL.DTOs.Auth;
using AIRecruitment.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIRecruitment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        await _authService.RegisterAsync(registerDto);
        return Ok(new{message = "Account created successfully."});
    }

        [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var response = await _authService.LoginAsync(loginDto);
        return Ok(response);
    }
}
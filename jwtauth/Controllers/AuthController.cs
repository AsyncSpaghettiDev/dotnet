
using Microsoft.AspNetCore.Mvc;
using jwtauth.Models;
using jwtauth.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using jwtauth.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace jwtauth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase {
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request ) {
        User? user = await authService.RegisterAsync(request);
        return user is null ? BadRequest("Username already exists.") : Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto >> Login(UserDto request) {
        TokenResponseDto? token = await authService.LoginAsync(request);

        return token is null ? BadRequest("Invalid username or password") : Ok(token) ;
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request) {
        TokenResponseDto? token = await authService.RefreshTokenAsync(request);
        if (token is null || token.AccessToken is null || token.RefreshToken is null) {
            return Unauthorized("Invalid refresh token");
        }
        return Ok(token);
    }

    [HttpGet]
    [Authorize]
    public IActionResult AuthenticatedOnlyEndpoint() {
        return Ok("You are authenticated");
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnlyEndpoint() {
        return Ok("You are an admin");
    }
}

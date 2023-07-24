using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;

namespace Delta.Controllers.API;

[ApiController]
[Route("api/user")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    
    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserModel user)
    {
        var userDto = new UserDto
        {
            UserName = user.UserName,
            Password = user.Password,
            Role = "Admin"
        };
        var registered = await _userService.RegisterUserAsync(userDto);
        if (!registered)
        {
            return BadRequest();
        }
        
        return Ok();
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserModel user)
    {
        var userDto = await _userService.GetUserAsync(user.UserName, "Admin");
        
        if (userDto == null)
        {
            return BadRequest("User not found");
        }
        
        if (!BCrypt.Net.BCrypt.Verify(user.Password, userDto.PasswordHash))
        {
            return BadRequest("Wrong password");
        }
        
        var token = CreateToken(userDto);
        
        return Ok(new {token});
    }
    
    private string CreateToken(UserDto userDto)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, userDto.UserName),
            new(ClaimTypes.Role, "Admin")
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthSettings:Token").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Delta.Models;
using Delta.Models.Dtos;
using System.Linq;
using Delta.Data;


namespace Delta.Services.UserService;

public class UserService : IUserService
{
    private readonly DeltaDbContext _context;
    
    
    public UserService(DeltaDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> RegisterUserAsync(UserDto userDto)
    {
        var any = _context.Users.Any(u => u.UserName == userDto.UserName && u.Role == userDto.Role);
        if (any)
        {
            return false;
        }
        
        var user = new User
        {
            UserName = userDto.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            Role = userDto.Role
        };
        
        await _context.Users.AddAsync(user);
        var savedCount = await _context.SaveChangesAsync();
        return savedCount > 0;
    }
    
    public Task<UserDto?> GetUserAsync(string userName, string role)
    {
        return _context.Users
            .Where(u => u.UserName == userName && u.Role == role)
            .Select(u => new UserDto
            {
                UserName = u.UserName,
                PasswordHash = u.PasswordHash,
                Role = u.Role
            })
            .SingleOrDefaultAsync();
    }
}
using Microsoft.EntityFrameworkCore;

namespace Delta.Models;

[PrimaryKey(nameof(UserName), nameof(Role))]
public class User
{
    public string UserName { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
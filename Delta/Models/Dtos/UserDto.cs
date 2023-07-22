namespace Delta.Models.Dtos;

public class UserDto
{
    public required string UserName { get; set; }
    public string? Password { get; set; }
    public string? PasswordHash { get; set; }
    public required string Role { get; set; }
}
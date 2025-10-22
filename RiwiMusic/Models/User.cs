namespace RiwiMusic.Models;
public class User
{// User : UserId UserName UserPassword UserEmail UserStatus
    public int UserId { get; init; }
    public string? UserName { get; set; }
    public string? UserPassword { get; set; }
    public string? UserEmail { get; set; }
    public bool UserStatus { get; set; }
}
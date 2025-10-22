using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace DigitalLibrary.Models;

[Index(nameof(Document), IsUnique = true)] 
public class User
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = String.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
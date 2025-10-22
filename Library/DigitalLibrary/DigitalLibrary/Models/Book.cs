using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace DigitalLibrary.Models;

[Index(nameof(Code), IsUnique = true)] 
public class Book
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string Code { get; set; } = String.Empty;
    public int Stock { get; set; }
}
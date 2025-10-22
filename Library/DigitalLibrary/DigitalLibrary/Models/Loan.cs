using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models;

public class Loan
{
    [Key] public int Id { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime ReturnDay { get; set; }
    public int UserId { get; set; } //Clave Foranea de Id User
    public int BookId { get; set; } //Clave Foranea de Id Book
    
    public User User { get; set; } = null!;
    public Book Book { get; set; } = null!;
}
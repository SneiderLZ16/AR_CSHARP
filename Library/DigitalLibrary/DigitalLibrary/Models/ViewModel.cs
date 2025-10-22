namespace DigitalLibrary.Models;

public class ViewModel
{
    public List<User> Users { get; set; } = new();   // inicializado
    public List<Book> Books { get; set; } = new();
    public List<Loan> Loans { get; set; } = new();
}
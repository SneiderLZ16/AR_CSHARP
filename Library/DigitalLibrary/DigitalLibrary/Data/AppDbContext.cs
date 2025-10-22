using DigitalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
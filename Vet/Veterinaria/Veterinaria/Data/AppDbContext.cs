using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Atencion> Atenciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql( //Connection con la base de datos
            "server=localhost;database=veterinaria;user=userv;password=123",
            new MySqlServerVersion(new Version(8, 0, 36))
        );
    }
}
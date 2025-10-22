using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class MascotaService
{
    private readonly AppDbContext _context;

    public MascotaService(AppDbContext context)
    {
        _context = context;
    }

    public Task<Mascota> Registrar(Mascota entity)
    {
        _context.Mascotas.Add(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<Mascota>> Listar()
    {
        return Task.FromResult<IEnumerable<Mascota>>(_context.Mascotas.ToList());
    }

    public Task<Mascota> Editar(Mascota entity)
    {
        _context.Mascotas.Update(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public bool Eliminar(int id)
    {
        var mascota = _context.Mascotas.Find(id);
        if (mascota == null) return false;
        _context.Mascotas.Remove(mascota);
        _context.SaveChanges();
        return true;
    }
}

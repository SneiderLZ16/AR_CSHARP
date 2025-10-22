using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class AtencionService
{
    private readonly AppDbContext _context;

    public AtencionService(AppDbContext context)
    {
        _context = context;
    }

    public Task<Atencion> Registrar(Atencion entity)
    {
        _context.Atenciones.Add(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<Atencion>> Listar()
    {
        return Task.FromResult<IEnumerable<Atencion>>(_context.Atenciones.ToList());
    }

    public Task<Atencion> Editar(Atencion entity)
    {
        _context.Atenciones.Update(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public bool Eliminar(int id)
    {
        var atencion = _context.Atenciones.Find(id);
        if (atencion == null) return false;
        _context.Atenciones.Remove(atencion);
        _context.SaveChanges();
        return true;
    }
}

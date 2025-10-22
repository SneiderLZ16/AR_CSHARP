using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class ClienteService : IPersona<Cliente>
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public Task<Cliente> Registrar(Cliente entity)
    {
        _context.Clientes.Add(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<Cliente>> Listar()
    {
        return Task.FromResult<IEnumerable<Cliente>>(_context.Clientes.ToList());
    }

    public Task<Cliente> Editar(Cliente entity)
    {
        _context.Clientes.Update(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }

    public bool Eliminar(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null) return false;
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return true;
    }
}
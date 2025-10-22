using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class VeterinarioService : IPersona<Veterinario>
{
	private readonly AppDbContext _context;

	public VeterinarioService(AppDbContext context)
	{
		_context = context;
	}

	public Task<Veterinario> Registrar(Veterinario entity)
	{
		_context.Veterinarios.Add(entity);
		_context.SaveChanges();
		return Task.FromResult(entity);
	}

	public Task<IEnumerable<Veterinario>> Listar()
	{
		return Task.FromResult<IEnumerable<Veterinario>>(_context.Veterinarios.ToList());
	}

	public Task<Veterinario> Editar(Veterinario entity)
	{
		_context.Veterinarios.Update(entity);
		_context.SaveChanges();
		return Task.FromResult(entity);
	}

	public bool Eliminar(int id)
	{
		var veterinario = _context.Veterinarios.Find(id);
		if (veterinario == null) return false;
		_context.Veterinarios.Remove(veterinario);
		_context.SaveChanges();
		return true;
	}
}

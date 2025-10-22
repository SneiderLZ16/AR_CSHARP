using Veterinaria.Models;

namespace Veterinaria.Interfaces;

public interface IPersona<T> where T : Persona
{
    Task<T> Registrar(T entity); //Registrar
    Task<IEnumerable<T>> Listar(); //Listar
    Task<T> Editar(T entity); //Editar
    bool Eliminar(int id); //Eliminar
}
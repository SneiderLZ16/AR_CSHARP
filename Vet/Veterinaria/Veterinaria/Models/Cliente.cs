using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Cliente : Persona //ClaseHija
{
    [Key] public int IdCliente { get; set; }
    [MaxLength(20)] public string? Telefono { get; set; }
    [MaxLength(100)] public string? CorreoElectronico { get; set; }

    protected Cliente()
    {
    }

    public Cliente(int idCliente, string nombre, string apellido, int edad, string telefono,
        string correoElectronico) :
        base(nombre, apellido, edad) //Constructor
    {
        IdCliente = idCliente;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
    }
}
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Veterinario : Persona //ClaseHija
{
    [Key] public int IdVeterinario { get; set; }
    [MaxLength(100)] public string? Especialidad { get; set; }
    public int AniosExperiencia { get; set; }

    public Veterinario()
    {
    }

    public Veterinario(int idVeterinario, string nombre, string apellido, int edad, string especialidad,
        int aniosExperiencia) : base(nombre, apellido, edad) //Constructor
    {
        IdVeterinario = idVeterinario;
        Especialidad = especialidad;
        AniosExperiencia = aniosExperiencia;
    }
}
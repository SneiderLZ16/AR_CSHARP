namespace Veterinaria.Models;

public abstract class Persona //SuperClase
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }

    protected Persona()
    {
    }

    protected Persona(string nombre, string apellido, int edad) //Constructor
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
    }
}
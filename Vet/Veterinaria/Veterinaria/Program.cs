using Veterinaria.Data;
namespace Veterinaria
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Verificar Connection con la DB
            using var context = new AppDbContext();
            try
            {
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("✅ Conexión a la base de datos exitosa.");
                }
                else
                {
                    Console.WriteLine("❌ No se pudo conectar a la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al intentar conectar a la base de datos:");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            
            //Iniciar Menu principal
            Menus.Menu menu = new Menus.Menu();
            menu.Mostrar();
        }
    }
}
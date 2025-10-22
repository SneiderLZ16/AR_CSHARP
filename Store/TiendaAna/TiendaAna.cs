namespace TiendaAna;
public class Tienda
{
    public static Dictionary<string, (double precio, int stock)> Productos = new() //Lista de Productos
    {
        { "alfajor", (1000, 25) },
        { "papas", (2000, 15) },
        { "supercoco", (500, 0) },
        { "chicle", (1800, 20) },
        { "chocolatina", (1200, 30) }
    };
    public static List<string> Carrito = new();
    public static double SubTotal;
    public static double Total;
    public static void ShowStock() //Mostrar lista de Productos
    {
        Console.WriteLine("<=== BIENVENIDO A LA TIENDA DE ANA ===>");
        Console.WriteLine("<=|PRODUCTO|PRECIO|CANTIDAD|=>");
        foreach (var item in Productos)
        {
            Console.WriteLine($"{item.Key}|{item.Value.precio}|{item.Value.stock}");
        }
    }
    public static void ProductoDeseado() //Pedir el Producto deseado
    {
        Console.WriteLine("¿Qué producto quieres comprar?");
        string productoDeseado = Console.ReadLine().ToLower();
        
        ValidarDisponible(productoDeseado); //Validar Producto
    }
    public static void ValidarDisponible(string productoD) //Validar si el Producto esta disponible
    {
        foreach (var item in Productos)
        {
            if (item.Key == productoD)
            {
                string producto = item.Key;
                int cantidad = item.Value.stock;
                double precio = item.Value.precio;
                CantidadProductos(producto, cantidad, precio); //Validar Cantidad
                return;
            }
        }
        Console.WriteLine("¡El producto no se encuentra disponible!");
        ProductoDeseado(); //Volver a pedir el Producto deseado
    }
    public static void CantidadProductos(string producto, int cantidad, double precio) //Validar Cantidad del Producto
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("No hay stock de este producto!");
            ShowStock(); //Mostrar lista de Productos
            Qsc();
        }
        else
        {
            Console.WriteLine($"¿Qué cantidad quieres comprar de {producto}?"); //Pedir la cantidad deseada
            int cantidadDeCompra = Convert.ToInt32(Console.ReadLine());
            
            if (cantidadDeCompra > 0 && cantidadDeCompra <= cantidad)
            {
                SubTotal += precio * cantidadDeCompra; //Calcular SubTotal
                Carrito.Add(producto); //Agregar Producto a la lista Carrito
                Productos[producto] = (precio, cantidad - cantidadDeCompra); //Modificar el Stock
                Console.WriteLine($"Se agregaron {cantidadDeCompra} {producto}: SubTotal: {SubTotal}"); //Mostrar productos agregados
                Qsc(); //Preguntar si quiere seguir comprando
            }
            else
            {
                Console.WriteLine($"No hay cantidad suficientes, tenemos {cantidad}");
                CantidadProductos(producto, cantidad, precio);
            }
        }
    }
    public static void Qsc() //Pregunar si quiere seguir comprando
    {
        Console.WriteLine($"[S].Seguir Comprando [P].Pagar [X].Salir");
        string enter = Console.ReadLine().ToLower();
        
        if (enter == "s")
        {
            ShowStock(); //Mostrar lista de Productos
            ProductoDeseado(); //Pedir el Producto deseado
        }else if (enter == "x")
        {
            Console.WriteLine("¡Gracias por comprar en la tienda de Ana!");
        }else if (enter == "p")
        {
            Descuento();
        }
    }
    public static void Descuento() //Validar si tiene Descuento
    {
        double porcentaje = SubTotal >= 20000 ? 0.20 : SubTotal >= 10000 ? 0.10 : 0; //Definir que Descuento tiene
        double descuento = SubTotal * porcentaje; //Calcular el Descuento
        Total = SubTotal - descuento; //Hacer el Descuento al Total
        Console.WriteLine($"Tuviste un descuento de [{descuento}]");
        Ticket();//Mostrar Ticket
    }
    public static void Ticket() //Mostrar Ticket
    {
        Console.WriteLine("== TICKET TOTAl ===");
        string carritos = String.Join(", ", Carrito);
        Console.WriteLine($"Compraste [{carritos}] y el total a pagar: TOTAL: [{Total}]");
        Console.WriteLine("¡Gracias por comprar en la tienda de Ana!");
    }
}
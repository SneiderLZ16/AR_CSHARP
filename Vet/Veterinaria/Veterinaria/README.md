# Documentación técnica del proyecto Veterinaria

## Estructura del proyecto

```bash
Veterinaria/
├── Data/                # Contexto y configuración de EF Core
├── Interfaces/          # Interfaces para servicios genéricos
├── Menus/               # Menús de consola para cada entidad y consultas avanzadas
├── Models/              # Clases de dominio: Persona, Cliente, Veterinario, Mascota, Atencion
├── Services/            # Servicios CRUD para cada entidad
└── Program.cs           # Punto de entrada principal
```

## Principales clases y responsabilidades

- **AppDbContext**: Contexto de Entity Framework Core, define los DbSet y la conexión a MySQL.
- **Persona (abstracta)**: Superclase para Cliente y Veterinario. Propiedades: Nombre, Apellido, Edad.
- **Cliente**: Hereda de Persona. Propiedades adicionales: IdCliente, Telefono, CorreoElectronico.
- **Veterinario**: Hereda de Persona. Propiedades adicionales: IdVeterinario, Especialidad, AniosExperiencia.
- **Mascota**: Propiedades: IdMascota, Nombre, Especie, Edad, ClienteId (FK).
- **Atencion**: Propiedades: IdAtencion, Fecha, Problema, MascotaId (FK), VeterinarioId (FK).
- **Servicios (ClienteService, VeterinarioService, MascotaService, AtencionService)**: CRUD para cada entidad usando AppDbContext.
- **Menús (MenuClientes, MenuVeterinarios, MenuMascotas, MenuAtenciones, MenuConsultasAvanzadas)**: Interfaz de usuario por consola para gestionar cada entidad y realizar consultas avanzadas con LINQ.

## Flujo de trabajo recomendado

1. Instala los paquetes y configura la cadena de conexión en `AppDbContext.cs`.
2. Realiza las migraciones y actualiza la base de datos.
3. Ejecuta el proyecto y navega por los menús para registrar, consultar, editar o eliminar información.
4. Usa el menú de consultas avanzadas para obtener información agregada relevante.

## Buenas prácticas y recomendaciones

- Mantén las versiones de los paquetes sincronizadas según lo indicado.
- Usa los servicios para toda la lógica de acceso a datos, nunca accedas a `AppDbContext` directamente desde los menús.
- Si agregas nuevas entidades, crea su modelo, servicio y menú correspondiente siguiendo el mismo patrón.
- Las consultas avanzadas usan LINQ y pueden ser extendidas fácilmente agregando nuevos métodos en `MenuConsultasAvanzadas`.

## Encapsulamiento y organización

- Todas las entidades y servicios están encapsulados en namespaces y carpetas específicas.
- Los constructores y métodos siguen el patrón de sobrecarga y herencia donde aplica (ver Persona, Cliente, Veterinario).
- Los menús solo interactúan con los servicios, nunca con la base de datos directamente.

## Ejemplo de uso de un servicio

```csharp
var context = new AppDbContext();
var clienteService = new ClienteService(context);
var nuevoCliente = new Cliente(1, "Juan", "Pérez", 30, "123456789", "juan@mail.com");
clienteService.Registrar(nuevoCliente);
var clientes = await clienteService.Listar();
```

## Consultas avanzadas (LINQ)

Las consultas avanzadas implementadas en el menú permiten:

- Listar todas las mascotas de un cliente.
- Obtener el veterinario con más atenciones.
- Saber la especie de mascota más atendida.
- Consultar el cliente con más mascotas registradas.

Puedes extenderlas fácilmente agregando nuevos métodos en el menú de consultas.

## Configuración de Entity Framework Core con MySQL

Este proyecto utiliza **Entity Framework Core** con **MySQL** mediante el proveedor Pomelo. La siguiente documentación incluye los paquetes exactos que se deben instalar y los comandos necesarios para iniciar el proyecto.

## Paquetes instalados y versiones exactas

- `Microsoft.EntityFrameworkCore` → Mapeado de objetos.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.9
```

- `Microsoft.EntityFrameworkCore.Design` → Necesario para scaffolding y generación de migraciones.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.9
```

- `Microsoft.EntityFrameworkCore.Tools` → Herramientas de consola para migraciones y actualización de base de datos.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.9
```

- `Pomelo.EntityFrameworkCore.MySql` → Proveedor de EF Core para MySQL/MariaDB.
  Versión: **9.0.0**

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
```

## Comandos útiles

- Crear una migración inicial:

```bash
dotnet ef migrations add InitialCreate
```

- Aplicar migraciones a la base de datos:

```bash
  dotnet ef database update
```

- Verificar paquetes instalados:

```bash
  dotnet list package
```

## Notas importantes

- Los paquetes deben instalarse en el proyecto `.csproj`.
- Se recomienda usar exactamente las versiones indicadas para evitar conflictos de compatibilidad.
- Se debe **adecuar la conexión a la base de datos** según el usuario, contraseña y nombre de la base que tengan configurados en su MySQL. Por ejemplo, en la carpeta `Data`, en el archivo `AppDbContext.cs`:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySql(
        "server=localhost;database=TU_BASE_DE_DATOS;user=TU_USUARIO;password=TU_CONTRASEÑA",
        new MySqlServerVersion(new Version(8, 0, 36))
    );
}
```

Reemplaza `TU_BASE_DE_DATOS`, `TU_USUARIO` y `TU_CONTRASEÑA` por los datos correspondientes a tu configuración.

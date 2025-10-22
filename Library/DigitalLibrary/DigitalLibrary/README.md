# Biblioteca Digital - Documentación Tecnica

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

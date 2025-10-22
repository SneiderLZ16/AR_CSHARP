# SkyTravel — MVC (.NET 8) + MySQL

Aplicación ASP.NET Core MVC para gestionar **vuelos**, **pasajeros** y **reservas**, con **PDF de tickets** (QuestPDF) y validaciones de negocio.

## Requisitos previos
- .NET 8 SDK
- MySQL 8+
- EF Core Tools: `dotnet tool install --global dotnet-ef`

## Configuración
1. Ajusta `appsettings.json` con tu cadena de conexión `MySql`.
2. Instala paquetes (si usas Visual Studio esto se restaura solo):
   - Pomelo.EntityFrameworkCore.MySql
   - Microsoft.EntityFrameworkCore.Design
   - QuestPDF
3. Crear DB y tablas:
```bash
dotnet ef migrations add InitialCreate -p SkyTravel.Web -s SkyTravel.Web
dotnet ef database update -p SkyTravel.Web -s SkyTravel.Web
```
4. Ejecutar:
```bash
dotnet run --project SkyTravel.Web
```

## Funcionalidades
- **Vuelos (Admin)**: crear/editar/listar, estado (Programado/EnVuelo/Finalizado/Cancelado), asientos disponibles, código único.
- **Pasajeros**: crear/editar/listar, documento único.
- **Reservas (Usuario)**: reservar (≤30 días antes), disponibilidad, una activa por vuelo, cancelar (libera asiento), completar (si vuelo finalizado), **Ticket PDF** + historial.

## Diseño
- **Bootstrap 5** + estilos suaves (`wwwroot/css/site.css`) para UI agradable.

## Autor
- Nombre: (tu nombre)
- Clan: (tu clan)
- Correo: (tu correo)
- Documento: (tu documento)

using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// MySQL
var cs = builder.Configuration.GetConnectionString("MySql")
         ?? "Server=localhost;Port=3306;Database=skytravel;User=root;Password=root;";
builder.Services.AddDbContext<SkyTravelDbContext>(opt =>
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

builder.Services.AddControllersWithViews();

// DI Services
builder.Services.AddScoped<ISeatAllocator, SeatAllocator>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Flights}/{action=Index}/{id?}");

app.Run();

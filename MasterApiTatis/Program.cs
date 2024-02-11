using MasterApiTatis.Infraestructur.Context;
using MasterApiTatis.Infraestructur.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión
var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(con, x => x.MigrationsHistoryTable("HistorialMigraciones"));

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(x => x.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning));
    }
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar Repositorios y Servicios AddApplicationServices
builder.Services.RegisterApplicationServices();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("AllowAll");
app.UseRouting();

// Descomentar si estás utilizando autenticación
// app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

// Aplicar migraciones automáticamente (tener cuidado en producción)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}

await app.RunAsync();

using DotNetEnv;
using DevForge.Application; // <-- Asegúrate de importar Application
using DevForge.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection") 
                       ?? throw new InvalidOperationException("Falta la cadena de conexión a PostgreSQL.");

// Inyección de Capas
builder.Services.AddApplication(); // <-- Registro de la capa de Aplicación
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();
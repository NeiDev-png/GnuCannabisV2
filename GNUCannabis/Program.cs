using AutoMapper;
using GNUCannabis.Data;
using Microsoft.EntityFrameworkCore;
using GNUCannabis.Repositories.Implements;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Implements;
using GNUCannabis.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrar DbContext primero
builder.Services.AddDbContext<GNUCannabisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Inyección de dependencias repositorio genérico
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlantaService, PlantaService>();
builder.Services.AddScoped<ICultivoService, CultivoService>();
builder.Services.AddScoped<IHistorialPlantaService, HistorialPlantaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


// Controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

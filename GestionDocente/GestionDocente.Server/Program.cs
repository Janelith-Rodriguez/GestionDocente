using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

//---------------------------------------------------------------------------------------------------
//Configuracion de los servicios en el constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IProfesorRepositorio, ProfesorRepositorio>();
builder.Services.AddScoped<ICursadoMateriaRepositorio, CursadoMateriaRepositorio>();
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ICUPOFProfesorRepositorio, CUPOFProfesorRepositorio>();



//---------------------------------------------------------------------------------------------------
//Construcción de la aplicación
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

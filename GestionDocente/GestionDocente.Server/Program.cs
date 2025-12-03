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

// Repositorios - Tablas Maestras
builder.Services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
builder.Services.AddScoped<ICarreraRepositorio, CarreraRepositorio>();
builder.Services.AddScoped<IMateriaRepositorio, MateriaRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IPlanEstudioRepositorio, PlanEstudioRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Repositorios - Entidades Relacionadas
builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>();
builder.Services.AddScoped<IProfesorRepositorio, ProfesorRepositorio>();
builder.Services.AddScoped<ICoordinadorRepositorio, CoordinadorRepositorio>();
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<IMateriaEnPlanEstudioRepositorio, MateriaEnPlanEstudioRepositorio>();
builder.Services.AddScoped<IInscripcionCarreraRepositorio, InscripcionCarreraRepositorio>();
builder.Services.AddScoped<ICursadoMateriaRepositorio, CursadoMateriaRepositorio>();
builder.Services.AddScoped<IClaseRepositorio, ClaseRepositorio>();
builder.Services.AddScoped<IEvaluacionRepositorio, EvaluacionRepositorio>();
builder.Services.AddScoped<INotaRepositorio, NotaRepositorio>();
builder.Services.AddScoped<IClaseAsistenciaRepositorio, ClaseAsistenciaRepositorio>();
builder.Services.AddScoped<ICorrelatividadRepositorio, CorrelatividadRepositorio>();
builder.Services.AddScoped<ICertificadoAlumnoRepositorio, CertificadoAlumnoRepositorio>();
builder.Services.AddScoped<ICUPOF_CoordinadorRepositorio, CUPOF_CoordinadorRepositorio>();
builder.Services.AddScoped<ICUPOF_ProfesorRepositorio, CUPOF_ProfesorRepositorio>();
builder.Services.AddScoped<IMABRepositorio, MABRepositorio>();

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

using GestionDocente.Client;
using GestionDocente.Client.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Servicios HTTP
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

// Servicios específicos - Tablas Maestras
builder.Services.AddScoped<ITipoDocumentoServicio, TipoDocumentoServicio>();
builder.Services.AddScoped<ICarreraServicio, CarreraServicio>();
builder.Services.AddScoped<IMateriaServicio, MateriaServicio>();
builder.Services.AddScoped<IPersonaServicio, PersonaServicio>();
builder.Services.AddScoped<IPlanEstudioServicio, PlanEstudioServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();

// Servicios específicos - Entidades Relacionadas
builder.Services.AddScoped<IAlumnoServicio, AlumnoServicio>();
builder.Services.AddScoped<IProfesorServicio, ProfesorServicio>();
builder.Services.AddScoped<ICoordinadorServicio, CoordinadorServicio>();
builder.Services.AddScoped<ITurnoServicio, TurnoServicio>();
builder.Services.AddScoped<IMateriaEnPlanEstudioServicio, MateriaEnPlanEstudioServicio>();
builder.Services.AddScoped<IInscripcionCarreraServicio, InscripcionCarreraServicio>();
builder.Services.AddScoped<ICursadoMateriaServicio, CursadoMateriaServicio>();
builder.Services.AddScoped<IClaseServicio, ClaseServicio>();
builder.Services.AddScoped<IEvaluacionServicio, EvaluacionServicio>();
builder.Services.AddScoped<INotaServicio, NotaServicio>();
builder.Services.AddScoped<IClaseAsistenciaServicio, ClaseAsistenciaServicio>();
builder.Services.AddScoped<ICorrelatividadServicio, CorrelatividadServicio>();
builder.Services.AddScoped<ICertificadoAlumnoServicio, CertificadoAlumnoServicio>();
builder.Services.AddScoped<ICUPOF_CoordinadorServicio, CUPOF_CoordinadorServicio>();
builder.Services.AddScoped<ICUPOF_ProfesorServicio, CUPOF_ProfesorServicio>();
builder.Services.AddScoped<IMABServicio, MABServicio>();

await builder.Build().RunAsync();

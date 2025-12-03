using AutoMapper;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionDocente.Server.Controllers
{
        [ApiController]
        [Route("api/Carreras")]
        public class CarreraController : ControllerBase
        {
            private readonly ICarreraRepositorio repositorio;
            private readonly IMapper mapper;

            public CarreraController(ICarreraRepositorio repositorio,
                                    IMapper mapper)
            {
                this.repositorio = repositorio;
                this.mapper = mapper;
            }

            [HttpGet]    //api/Carreras
            public async Task<ActionResult<List<Carrera>>> Get()
            {
                return await repositorio.Select();
            }

            [HttpGet("{id:int}")] //api/Carreras/2
            public async Task<ActionResult<Carrera>> Get(int id)
            {
                Carrera? entidad = await repositorio.SelectById(id);
                if (entidad == null)
                {
                    return NotFound();
                }
                return entidad;
            }

            [HttpGet("GetByNombre/{nombre}")] //api/Carreras/GetByNombre/Ingeniería
            public async Task<ActionResult<Carrera>> GetByNombre(string nombre)
            {
                Carrera? entidad = await repositorio.SelectByNombre(nombre);
                if (entidad == null)
                {
                    return NotFound();
                }
                return entidad;
            }

            [HttpGet("existe/{id:int}")] //api/Carreras/existe/2
            public async Task<ActionResult<bool>> Existe(int id)
            {
                var existe = await repositorio.Existe(id);
                return existe;
            }

            [HttpPost]
            public async Task<ActionResult<int>> Post(CrearCarreraDTO entidadDTO)
            {
                try
                {
                    Carrera entidad = mapper.Map<Carrera>(entidadDTO);
                    return await repositorio.Insert(entidad);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }

            [HttpPut("{id:int}")] //api/Carreras/2
            public async Task<ActionResult> Put(int id, [FromBody] Carrera entidad)
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var existente = await repositorio.SelectById(id);

                if (existente == null)
                {
                    return NotFound("No existe la carrera buscada.");
                }

                existente.Nombre = entidad.Nombre;
                existente.DuracionCarrera = entidad.DuracionCarrera;
                existente.Modalidad = entidad.Modalidad;
                existente.Activo = entidad.Activo;

                try
                {
                    await repositorio.Update(id, existente);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id:int}")] //api/Carreras/2
            public async Task<ActionResult> Delete(int id)
            {
                var existe = await repositorio.Existe(id);
                if (!existe)
                {
                    return NotFound($"La carrera {id} no existe.");
                }
                if (await repositorio.Delete(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
}

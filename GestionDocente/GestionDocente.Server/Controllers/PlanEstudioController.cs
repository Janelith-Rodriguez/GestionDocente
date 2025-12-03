using Microsoft.AspNetCore.Mvc;
using GestionDocente.BD.Data.Entity;
using GestionDocente.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestionDocente.Shared.DTO;
using AutoMapper;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/PlanesEstudio")]
    public class PlanesEstudioController : ControllerBase
    {
        private readonly IPlanEstudioRepositorio repositorio;
        private readonly IMapper mapper;

        public PlanesEstudioController(IPlanEstudioRepositorio repositorio,
                                     IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/PlanesEstudio
        public async Task<ActionResult<List<PlanEstudio>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/PlanesEstudio/2
        public async Task<ActionResult<PlanEstudio>> Get(int id)
        {
            PlanEstudio? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByNombre/{nombre}")] //api/PlanesEstudio/GetByNombre/Plan2024
        public async Task<ActionResult<PlanEstudio>> GetByNombre(string nombre)
        {
            PlanEstudio? entidad = await repositorio.SelectByNombre(nombre);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/PlanesEstudio/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPlanEstudioDTO entidadDTO)
        {
            try
            {
                PlanEstudio entidad = mapper.Map<PlanEstudio>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/PlanesEstudio/2
        public async Task<ActionResult> Put(int id, [FromBody] PlanEstudio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var existente = await repositorio.SelectById(id);

            if (existente == null)
            {
                return NotFound("No existe el plan de estudio buscado.");
            }

            existente.Nombre = entidad.Nombre;
            existente.Anno = entidad.Anno;
            existente.EstadoPlan = entidad.EstadoPlan;
            existente.CarreraId = entidad.CarreraId;
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

        [HttpDelete("{id:int}")] //api/PlanesEstudio/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El plan de estudio {id} no existe.");
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

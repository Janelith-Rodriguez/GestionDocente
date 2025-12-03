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
    [Route("api/Personas")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepositorio repositorio;
        private readonly IMapper mapper;

        public PersonasController(IPersonaRepositorio repositorio,
                                IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/Personas
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Personas/2
        public async Task<ActionResult<Persona>> Get(int id)
        {
            Persona? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByDocumento/{documento}")] //api/Personas/GetByDocumento/12345678
        public async Task<ActionResult<Persona>> GetByDocumento(string documento)
        {
            Persona? entidad = await repositorio.SelectByDocumento(documento);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/Personas/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPersonaDTO entidadDTO)
        {
            try
            {
                Persona entidad = mapper.Map<Persona>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Personas/2
        public async Task<ActionResult> Put(int id, [FromBody] Persona entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var existente = await repositorio.SelectById(id);

            if (existente == null)
            {
                return NotFound("No existe la persona buscada.");
            }

            existente.Nombre = entidad.Nombre;
            existente.Apellido = entidad.Apellido;
            existente.Documento = entidad.Documento;
            existente.Telefono = entidad.Telefono;
            existente.Domicilio = entidad.Domicilio;
            existente.TipoDocumentoId = entidad.TipoDocumentoId;
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

        [HttpDelete("{id:int}")] //api/Personas/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La persona {id} no existe.");
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

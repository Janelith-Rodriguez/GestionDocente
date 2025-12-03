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
    [Route("api/TipoDocumentos")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoRepositorio repositorio;
        private readonly IMapper mapper;

        public TipoDocumentoController(ITipoDocumentoRepositorio repositorio,
                                      IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/TipoDocumentos
        public async Task<ActionResult<List<TipoDocumento>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/TipoDocumentos/2
        public async Task<ActionResult<TipoDocumento>> Get(int id)
        {
            TipoDocumento? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByCod/{cod}")] //api/TipoDocumentos/GetByCod/DNI
        public async Task<ActionResult<TipoDocumento>> GetByCod(string cod)
        {
            TipoDocumento? entidad = await repositorio.SelectByCod(cod);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/TipoDocumentos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTipoDocumentoDTO entidadDTO)
        {
            try
            {
                TipoDocumento entidad = mapper.Map<TipoDocumento>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TipoDocumentos/2
        public async Task<ActionResult> Put(int id, [FromBody] TipoDocumento entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var existente = await repositorio.SelectById(id);

            if (existente == null)
            {
                return NotFound("No existe el tipo de documento buscado.");
            }

            existente.Codigo = entidad.Codigo;
            existente.Nombre = entidad.Nombre;
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

        [HttpDelete("{id:int}")] //api/TipoDocumentos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
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

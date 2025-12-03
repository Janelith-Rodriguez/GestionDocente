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
    [Route("api/Materias")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaRepositorio repositorio;
        private readonly IMapper mapper;

        public MateriasController(IMateriaRepositorio repositorio,
                                IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/Materias
        public async Task<ActionResult<List<Materia>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Materias/2
        public async Task<ActionResult<Materia>> Get(int id)
        {
            Materia? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByNombre/{nombre}")] //api/Materias/GetByNombre/Matemática
        public async Task<ActionResult<Materia>> GetByNombre(string nombre)
        {
            Materia? entidad = await repositorio.SelectByNombre(nombre);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/Materias/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMateriaDTO entidadDTO)
        {
            try
            {
                Materia entidad = mapper.Map<Materia>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Materias/2
        public async Task<ActionResult> Put(int id, [FromBody] Materia entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var existente = await repositorio.SelectById(id);

            if (existente == null)
            {
                return NotFound("No existe la materia buscada.");
            }

            existente.Nombre = entidad.Nombre;
            existente.Formato = entidad.Formato;
            existente.Formacion = entidad.Formacion;
            existente.ResolucionMinisterial = entidad.ResolucionMinisterial;
            existente.Anno = entidad.Anno;
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

        [HttpDelete("{id:int}")] //api/Materias/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La materia {id} no existe.");
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

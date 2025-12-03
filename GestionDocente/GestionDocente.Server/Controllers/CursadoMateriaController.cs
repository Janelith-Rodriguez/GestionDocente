using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/CursadosMateria")]
    public class CursadosMateriaController : ControllerBase
    {
        private readonly ICursadoMateriaRepositorio repositorio;

        public CursadosMateriaController(ICursadoMateriaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/CursadosMateria
        public async Task<ActionResult<List<CursadoMateria>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/CursadosMateria/2
        public async Task<ActionResult<CursadoMateria>> Get(int id)
        {
            CursadoMateria? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByAlumno/{alumnoId}")] //api/CursadosMateria/GetByAlumno/1
        public async Task<ActionResult<List<CursadoMateria>>> GetByAlumno(int alumnoId)
        {
            var entidades = await repositorio.SelectByAlumno(alumnoId);
            return entidades;
        }

        [HttpGet("GetByTurno/{turnoId}")] //api/CursadosMateria/GetByTurno/1
        public async Task<ActionResult<List<CursadoMateria>>> GetByTurno(int turnoId)
        {
            var entidades = await repositorio.SelectByTurno(turnoId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/CursadosMateria/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CursadoMateria entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/CursadosMateria/2
        public async Task<ActionResult> Put(int id, [FromBody] CursadoMateria entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var resultado = await repositorio.Update(id, entidad);

                if (!resultado)
                {
                    return BadRequest("No se pudo actualizar el cursado de materia");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/CursadosMateria/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El cursado de materia no se pudo borrar");
            }
            return Ok();
        }
    }
}





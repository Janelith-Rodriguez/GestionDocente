using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/ClasesAsistencias")]
    public class ClasesAsistenciasController : ControllerBase
    {
        private readonly IClaseAsistenciaRepositorio repositorio;

        public ClasesAsistenciasController(IClaseAsistenciaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/ClasesAsistencias
        public async Task<ActionResult<List<ClaseAsistencia>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/ClasesAsistencias/2
        public async Task<ActionResult<ClaseAsistencia>> Get(int id)
        {
            ClaseAsistencia? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByClase/{claseId}")] //api/ClasesAsistencias/GetByClase/1
        public async Task<ActionResult<List<ClaseAsistencia>>> GetByClase(int claseId)
        {
            var entidades = await repositorio.SelectByClase(claseId);
            return entidades;
        }

        [HttpGet("GetByCursado/{cursadoMateriaId}")] //api/ClasesAsistencias/GetByCursado/1
        public async Task<ActionResult<List<ClaseAsistencia>>> GetByCursado(int cursadoMateriaId)
        {
            var entidades = await repositorio.SelectByCursadoMateria(cursadoMateriaId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/ClasesAsistencias/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ClaseAsistencia entidad)
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

        [HttpPut("{id:int}")] //api/ClasesAsistencias/2
        public async Task<ActionResult> Put(int id, [FromBody] ClaseAsistencia entidad)
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
                    return BadRequest("No se pudo actualizar la asistencia de clase");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/ClasesAsistencias/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La asistencia de clase no se pudo borrar");
            }
            return Ok();
        }
    }
}

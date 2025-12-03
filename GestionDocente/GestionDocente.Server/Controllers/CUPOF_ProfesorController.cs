using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/CUPOFProfesores")]
    public class CUPOFProfesoresController : ControllerBase
    {
        private readonly ICUPOF_ProfesorRepositorio repositorio;

        public CUPOFProfesoresController(ICUPOF_ProfesorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/CUPOFProfesores
        public async Task<ActionResult<List<CUPOF_Profesor>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/CUPOFProfesores/2
        public async Task<ActionResult<CUPOF_Profesor>> Get(int id)
        {
            CUPOF_Profesor? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByTurno/{turnoId}")] //api/CUPOFProfesores/GetByTurno/1
        public async Task<ActionResult<List<CUPOF_Profesor>>> GetByTurno(int turnoId)
        {
            var entidades = await repositorio.SelectByTurno(turnoId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/CUPOFProfesores/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CUPOF_Profesor entidad)
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

        [HttpPut("{id:int}")] //api/CUPOFProfesores/2
        public async Task<ActionResult> Put(int id, [FromBody] CUPOF_Profesor entidad)
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
                    return BadRequest("No se pudo actualizar el CUPOF del profesor");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/CUPOFProfesores/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El CUPOF del profesor no se pudo borrar");
            }
            return Ok();
        }
    }
}



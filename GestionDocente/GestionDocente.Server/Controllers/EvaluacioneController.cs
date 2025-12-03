using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Evaluaciones")]
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionRepositorio repositorio;

        public EvaluacionesController(IEvaluacionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Evaluaciones
        public async Task<ActionResult<List<Evaluacion>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Evaluaciones/2
        public async Task<ActionResult<Evaluacion>> Get(int id)
        {
            Evaluacion? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByTurno/{turnoId}")] //api/Evaluaciones/GetByTurno/1
        public async Task<ActionResult<List<Evaluacion>>> GetByTurno(int turnoId)
        {
            var entidades = await repositorio.SelectByTurno(turnoId);
            return entidades;
        }

        [HttpGet("GetByTipo/{tipo}")] //api/Evaluaciones/GetByTipo/Parcial
        public async Task<ActionResult<List<Evaluacion>>> GetByTipo(string tipo)
        {
            var entidades = await repositorio.SelectByTipo(tipo);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Evaluaciones/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Evaluacion entidad)
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

        [HttpPut("{id:int}")] //api/Evaluaciones/2
        public async Task<ActionResult> Put(int id, [FromBody] Evaluacion entidad)
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
                    return BadRequest("No se pudo actualizar la evaluación");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Evaluaciones/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La evaluación no se pudo borrar");
            }
            return Ok();
        }
    }
}
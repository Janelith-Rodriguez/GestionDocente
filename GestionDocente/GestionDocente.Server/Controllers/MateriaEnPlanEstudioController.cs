using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/MateriasEnPlanEstudio")]
    public class MateriasEnPlanEstudioController : ControllerBase
    {
        private readonly IMateriaEnPlanEstudioRepositorio repositorio;

        public MateriasEnPlanEstudioController(IMateriaEnPlanEstudioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/MateriasEnPlanEstudio
        public async Task<ActionResult<List<MateriaEnPlanEstudio>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/MateriasEnPlanEstudio/2
        public async Task<ActionResult<MateriaEnPlanEstudio>> Get(int id)
        {
            MateriaEnPlanEstudio? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByPlan/{planEstudioId}")] //api/MateriasEnPlanEstudio/GetByPlan/1
        public async Task<ActionResult<List<MateriaEnPlanEstudio>>> GetByPlan(int planEstudioId)
        {
            var entidades = await repositorio.SelectByPlanEstudio(planEstudioId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/MateriasEnPlanEstudio/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(MateriaEnPlanEstudio entidad)
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

        [HttpPut("{id:int}")] //api/MateriasEnPlanEstudio/2
        public async Task<ActionResult> Put(int id, [FromBody] MateriaEnPlanEstudio entidad)
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
                    return BadRequest("No se pudo actualizar la materia en plan de estudio");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/MateriasEnPlanEstudio/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La materia en plan de estudio no se pudo borrar");
            }
            return Ok();
        }
    }
}

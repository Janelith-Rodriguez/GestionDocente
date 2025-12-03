using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/MABs")]
    public class MABsController : ControllerBase
    {
        private readonly IMABRepositorio repositorio;

        public MABsController(IMABRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/MABs
        public async Task<ActionResult<List<MAB>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/MABs/2
        public async Task<ActionResult<MAB>> Get(int id)
        {
            MAB? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByProfesor/{profesorId}")] //api/MABs/GetByProfesor/1
        public async Task<ActionResult<List<MAB>>> GetByProfesor(int profesorId)
        {
            var entidades = await repositorio.SelectByProfesor(profesorId);
            return entidades;
        }

        [HttpGet("GetByCUPOF/{cupofProfesorId}")] //api/MABs/GetByCUPOF/1
        public async Task<ActionResult<List<MAB>>> GetByCUPOF(int cupofProfesorId)
        {
            var entidades = await repositorio.SelectByCUPOFProfesor(cupofProfesorId);
            return entidades;
        }

        [HttpGet("GetByIdMab/{idMab}")] //api/MABs/GetByIdMab/MAB001
        public async Task<ActionResult<MAB>> GetByIdMab(string idMab)
        {
            MAB? entidad = await repositorio.SelectByIdMab(idMab);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/MABs/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(MAB entidad)
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

        [HttpPut("{id:int}")] //api/MABs/2
        public async Task<ActionResult> Put(int id, [FromBody] MAB entidad)
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
                    return BadRequest("No se pudo actualizar el MAB");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/MABs/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El MAB no se pudo borrar");
            }
            return Ok();
        }
    }
}
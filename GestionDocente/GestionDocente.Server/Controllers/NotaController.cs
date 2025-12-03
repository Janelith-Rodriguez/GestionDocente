using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Notas")]
    public class NotasController : ControllerBase
    {
        private readonly INotaRepositorio repositorio;

        public NotasController(INotaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Notas
        public async Task<ActionResult<List<Nota>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Notas/2
        public async Task<ActionResult<Nota>> Get(int id)
        {
            Nota? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByEvaluacion/{evaluacionId}")] //api/Notas/GetByEvaluacion/1
        public async Task<ActionResult<List<Nota>>> GetByEvaluacion(int evaluacionId)
        {
            var entidades = await repositorio.SelectByEvaluacion(evaluacionId);
            return entidades;
        }

        [HttpGet("GetByCursado/{cursadoMateriaId}")] //api/Notas/GetByCursado/1
        public async Task<ActionResult<List<Nota>>> GetByCursado(int cursadoMateriaId)
        {
            var entidades = await repositorio.SelectByCursadoMateria(cursadoMateriaId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Notas/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Nota entidad)
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

        [HttpPut("{id:int}")] //api/Notas/2
        public async Task<ActionResult> Put(int id, [FromBody] Nota entidad)
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
                    return BadRequest("No se pudo actualizar la nota");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Notas/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La nota no se pudo borrar");
            }
            return Ok();
        }
    }
}

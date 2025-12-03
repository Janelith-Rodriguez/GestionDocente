using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Clases")]
    public class ClasesController : ControllerBase
    {
        private readonly IClaseRepositorio repositorio;

        public ClasesController(IClaseRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Clases
        public async Task<ActionResult<List<Clase>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Clases/2
        public async Task<ActionResult<Clase>> Get(int id)
        {
            Clase? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByTurno/{turnoId}")] //api/Clases/GetByTurno/1
        public async Task<ActionResult<List<Clase>>> GetByTurno(int turnoId)
        {
            var entidades = await repositorio.SelectByTurno(turnoId);
            return entidades;
        }

        [HttpGet("GetByFecha/{fecha}")] //api/Clases/GetByFecha/2024-01-15
        public async Task<ActionResult<List<Clase>>> GetByFecha(DateTime fecha)
        {
            var entidades = await repositorio.SelectByFecha(fecha);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Clases/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Clase entidad)
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

        [HttpPut("{id:int}")] //api/Clases/2
        public async Task<ActionResult> Put(int id, [FromBody] Clase entidad)
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
                    return BadRequest("No se pudo actualizar la clase");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Clases/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La clase no se pudo borrar");
            }
            return Ok();
        }
    }
}

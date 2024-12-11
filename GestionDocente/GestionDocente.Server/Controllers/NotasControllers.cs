using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Notas")]
    public class NotasControllers : ControllerBase
    {
        private readonly INotaRepositorio repositorio;
        private readonly IMapper mapper;

        public NotasControllers(INotaRepositorio repositorio,
                                 IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Nota>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Nota>> GetById(int id)
        {
            Nota? d = await repositorio.SelectById(id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearNotaDTO entidadDTO)
        {
            try
            {


                Nota entidad = mapper.Map<Nota>(entidadDTO);

                return await repositorio.Insert(entidad);


            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                //throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Nota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await repositorio.SelectById(id);


            if (d == null)
            {
                return NotFound("La nota buscada no existe.");
            }

            d.EvaluacionId = entidad.EvaluacionId;
            d.ValorNota = entidad.ValorNota;
            d.Asistencia = entidad.Asistencia;
            d.CursadoMateriaId = entidad.CursadoMateriaId;
            d.Activo = entidad.Activo;
            try
            {
                await repositorio.Update(id, d);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La nota {id} no existe.");
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

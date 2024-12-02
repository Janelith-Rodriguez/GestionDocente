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
    [Route("api/Profesores")]
    public class ProfesoresControllers : ControllerBase
    {
        private readonly IProfesorRepositorio repositorio;
        private readonly IMapper mapper;

        public ProfesoresControllers(IProfesorRepositorio repositorio,
                                     IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Peticiones Get

        [HttpGet]  //api/Profesores
        public async Task<ActionResult<List<Profesor>>> Get()
        {
            return await repositorio.Select();
            //return await context.Profesores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesor>> Get(int id)
        {
            Profesor? d = await repositorio.SelectById(id);
            //Profesor ? d = await context.Profesores
            //                  .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }

        [HttpGet("existe/{id:int}")] //api/Profesores/existe
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            //var existe = await context.Profesores.AnyAsync(x => x.Id == id);
            return existe;

        }

        #endregion

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearProfesorDTO entidadDTO)
        {
            try
            {
                //Profesor entidad = new Profesor();
                //entidad.Usuario = entidadDTO.Usuario;
                //entidad.Estado = entidadDTO.Estado;

                Profesor entidad = mapper.Map<Profesor>(entidadDTO);

                return await repositorio.Insert(entidad);

                //context.Profesores.Add(entidad);
                //await context.SaveChangesAsync();
                //return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                //throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Profesor entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await repositorio.SelectById(id);
            //var d = await context.Profesores
            //                      .Where(reg => reg.Id == id)
            //                      .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe el profesor buscado");
            }

            d.Usuario = entidad.Usuario;
            d.Estado = entidad.Estado;
            d.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, d);
                //context.Profesores.Update(d);
                //await context.SaveChangesAsync();
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
            //var existe = await context.Profesores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El profesor {id} no existe");
            }
            //Profesor EntidadABorrar = new Profesor();
            //EntidadABorrar.Id = id;

            //context.Remove(EntidadABorrar);
            //await context.SaveChangesAsync();
            //return Ok();
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

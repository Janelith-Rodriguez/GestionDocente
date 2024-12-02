using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuariosControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public UsuariosControllers(Context context,
                                   IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            Usuario? d = await context.Usuarios
                              .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();
                //entidad.Email = entidadDTO.Email;
                //entidad.Contrasena = entidadDTO.Contrasena;

                Usuario entidad = mapper.Map<Usuario>(entidadDTO);

                context.Usuarios.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await context.Usuarios
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe el usuario buscado");
            }

            d.Persona = entidad.Persona;
            d.Email = entidad.Email;
            d.Contrasena = entidad.Contrasena;
            d.Estado = entidad.Estado;
            d.Activo = entidad.Activo;
            try
            {
                context.Usuarios.Update(d);
                await context.SaveChangesAsync();
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
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Usuario {id} no existe");
            }
            Usuario EntidadABorrar = new Usuario();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}

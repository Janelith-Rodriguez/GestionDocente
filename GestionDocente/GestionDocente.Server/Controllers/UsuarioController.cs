using Microsoft.AspNetCore.Mvc;
using GestionDocente.BD.Data.Entity;
using GestionDocente.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestionDocente.Shared.DTO;
using AutoMapper;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioRepositorio repositorio,
                                IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]    //api/Usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Usuarios/2
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByEmail/{email}")] //api/Usuarios/GetByEmail/usuario@mail.com
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            Usuario? entidad = await repositorio.SelectByEmail(email);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/Usuarios/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                Usuario entidad = mapper.Map<Usuario>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Usuarios/2
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var existente = await repositorio.SelectById(id);

            if (existente == null)
            {
                return NotFound("No existe el usuario buscado.");
            }

            existente.Email = entidad.Email;
            existente.Contrasena = entidad.Contrasena;
            existente.Estado = entidad.Estado;
            existente.PersonaId = entidad.PersonaId;
            existente.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, existente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Usuarios/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe.");
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

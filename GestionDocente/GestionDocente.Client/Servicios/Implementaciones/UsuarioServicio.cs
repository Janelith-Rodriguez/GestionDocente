using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class UsuarioServicio : Servicio<Usuario>, IUsuarioServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Usuarios";

        public UsuarioServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Usuario>> GetByEmail(string email)
        {
            return await _httpServicio.Get<Usuario>($"{BaseUrl}/GetByEmail/{email}");
        }

        public async Task<HttpRespuesta<Usuario>> GetByPersona(int personaId)
        {
            return await _httpServicio.Get<Usuario>($"{BaseUrl}/GetByPersona/{personaId}");
        }

        public async Task<HttpRespuesta<List<Usuario>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<Usuario>>($"{BaseUrl}/GetByEstado/{estado}");
        }
    }
}

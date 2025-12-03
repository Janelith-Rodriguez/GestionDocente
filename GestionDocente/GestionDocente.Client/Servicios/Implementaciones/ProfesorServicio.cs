using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class ProfesorServicio : Servicio<Profesor>, IProfesorServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Profesores";

        public ProfesorServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Profesor>> GetByUsuario(int usuarioId)
        {
            return await _httpServicio.Get<Profesor>($"{BaseUrl}/GetByUsuario/{usuarioId}");
        }

        public async Task<HttpRespuesta<List<Profesor>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<Profesor>>($"{BaseUrl}/GetByEstado/{estado}");
        }
    }
}

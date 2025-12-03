using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class AlumnoServicio : Servicio<Alumno>, IAlumnoServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Alumnos";

        public AlumnoServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Alumno>> GetByUsuario(int usuarioId)
        {
            return await _httpServicio.Get<Alumno>($"{BaseUrl}/GetByUsuario/{usuarioId}");
        }

        public async Task<HttpRespuesta<List<Alumno>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<Alumno>>($"{BaseUrl}/GetByEstado/{estado}");
        }

        public async Task<HttpRespuesta<List<Alumno>>> GetByPais(string pais)
        {
            return await _httpServicio.Get<List<Alumno>>($"{BaseUrl}/GetByPais/{pais}");
        }
    }
}

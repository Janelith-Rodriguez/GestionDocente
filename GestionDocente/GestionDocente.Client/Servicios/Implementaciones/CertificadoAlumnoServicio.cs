using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CertificadoAlumnoServicio : Servicio<CertificadoAlumno>, ICertificadoAlumnoServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/CertificadosAlumno";

        public CertificadoAlumnoServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<CertificadoAlumno>>> GetByNombre(string nombre)
        {
            return await _httpServicio.Get<List<CertificadoAlumno>>($"{BaseUrl}/GetByNombre/{nombre}");
        }

        public async Task<HttpRespuesta<List<CertificadoAlumno>>> GetByDuracion(string duracion)
        {
            return await _httpServicio.Get<List<CertificadoAlumno>>($"{BaseUrl}/GetByDuracion/{duracion}");
        }

        public async Task<HttpRespuesta<List<CertificadoAlumno>>> GetByModalidad(string modalidad)
        {
            return await _httpServicio.Get<List<CertificadoAlumno>>($"{BaseUrl}/GetByModalidad/{modalidad}");
        }
    }
}

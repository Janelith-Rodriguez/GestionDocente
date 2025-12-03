using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class TurnoServicio : Servicio<Turno>, ITurnoServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Turnos";

        public TurnoServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<Turno>>> GetByMateriaPlan(int materiaPlanId)
        {
            return await _httpServicio.Get<List<Turno>>($"{BaseUrl}/GetByMateria/{materiaPlanId}");
        }

        public async Task<HttpRespuesta<List<Turno>>> GetByProfesor(int profesorId)
        {
            return await _httpServicio.Get<List<Turno>>($"{BaseUrl}/GetByProfesor/{profesorId}");
        }

        public async Task<HttpRespuesta<List<Turno>>> GetByCicloLectivo(int annoCicloLectivo)
        {
            return await _httpServicio.Get<List<Turno>>($"{BaseUrl}/GetByCicloLectivo/{annoCicloLectivo}");
        }

        public async Task<HttpRespuesta<List<Turno>>> GetBySede(string sede)
        {
            return await _httpServicio.Get<List<Turno>>($"{BaseUrl}/GetBySede/{sede}");
        }
    }
}

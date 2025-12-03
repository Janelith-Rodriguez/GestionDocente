using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class ClaseServicio : Servicio<Clase>, IClaseServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Clases";

        public ClaseServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<Clase>>> GetByTurno(int turnoId)
        {
            return await _httpServicio.Get<List<Clase>>($"{BaseUrl}/GetByTurno/{turnoId}");
        }

        public async Task<HttpRespuesta<List<Clase>>> GetByFecha(DateTime fecha)
        {
            return await _httpServicio.Get<List<Clase>>($"{BaseUrl}/GetByFecha/{fecha:yyyy-MM-dd}");
        }

        public async Task<HttpRespuesta<List<Clase>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _httpServicio.Get<List<Clase>>($"{BaseUrl}/GetByRangoFechas/{fechaInicio:yyyy-MM-dd}/{fechaFin:yyyy-MM-dd}");
        }
    }
}
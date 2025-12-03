using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class EvaluacionServicio : Servicio<Evaluacion>, IEvaluacionServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Evaluaciones";

        public EvaluacionServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<Evaluacion>>> GetByTurno(int turnoId)
        {
            return await _httpServicio.Get<List<Evaluacion>>($"{BaseUrl}/GetByTurno/{turnoId}");
        }

        public async Task<HttpRespuesta<List<Evaluacion>>> GetByTipo(string tipoEvaluacion)
        {
            return await _httpServicio.Get<List<Evaluacion>>($"{BaseUrl}/GetByTipo/{tipoEvaluacion}");
        }

        public async Task<HttpRespuesta<List<Evaluacion>>> GetByFecha(DateTime fecha)
        {
            return await _httpServicio.Get<List<Evaluacion>>($"{BaseUrl}/GetByFecha/{fecha:yyyy-MM-dd}");
        }

        public async Task<HttpRespuesta<List<Evaluacion>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _httpServicio.Get<List<Evaluacion>>($"{BaseUrl}/GetByRangoFechas/{fechaInicio:yyyy-MM-dd}/{fechaFin:yyyy-MM-dd}");
        }
    }
}

using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class MABServicio : Servicio<MAB>, IMABServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/MABs";

        public MABServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<MAB>>> GetByProfesor(int profesorId)
        {
            return await _httpServicio.Get<List<MAB>>($"{BaseUrl}/GetByProfesor/{profesorId}");
        }

        public async Task<HttpRespuesta<List<MAB>>> GetByCUPOFProfesor(int cupofProfesorId)
        {
            return await _httpServicio.Get<List<MAB>>($"{BaseUrl}/GetByCUPOF/{cupofProfesorId}");
        }

        public async Task<HttpRespuesta<MAB>> GetByIdMab(string idMab)
        {
            return await _httpServicio.Get<MAB>($"{BaseUrl}/GetByIdMab/{idMab}");
        }

        public async Task<HttpRespuesta<List<MAB>>> GetBySitRevista(string sitRevista)
        {
            return await _httpServicio.Get<List<MAB>>($"{BaseUrl}/GetBySitRevista/{sitRevista}");
        }

        public async Task<HttpRespuesta<List<MAB>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _httpServicio.Get<List<MAB>>($"{BaseUrl}/GetByRangoFechas/{fechaInicio:yyyy-MM-dd}/{fechaFin:yyyy-MM-dd}");
        }
    }
}

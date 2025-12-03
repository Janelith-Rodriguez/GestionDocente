using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class ClaseAsistenciaServicio : Servicio<ClaseAsistencia>, IClaseAsistenciaServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/ClasesAsistencias";

        public ClaseAsistenciaServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<ClaseAsistencia>>> GetByClase(int claseId)
        {
            return await _httpServicio.Get<List<ClaseAsistencia>>($"{BaseUrl}/GetByClase/{claseId}");
        }

        public async Task<HttpRespuesta<List<ClaseAsistencia>>> GetByCursadoMateria(int cursadoMateriaId)
        {
            return await _httpServicio.Get<List<ClaseAsistencia>>($"{BaseUrl}/GetByCursado/{cursadoMateriaId}");
        }

        public async Task<HttpRespuesta<List<ClaseAsistencia>>> GetByAsistencia(char asistencia)
        {
            return await _httpServicio.Get<List<ClaseAsistencia>>($"{BaseUrl}/GetByAsistencia/{asistencia}");
        }
    }
}

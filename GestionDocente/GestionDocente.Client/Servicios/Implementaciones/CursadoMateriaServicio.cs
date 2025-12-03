using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CursadoMateriaServicio : Servicio<CursadoMateria>, ICursadoMateriaServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/CursadosMateria";

        public CursadoMateriaServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<CursadoMateria>>> GetByAlumno(int alumnoId)
        {
            return await _httpServicio.Get<List<CursadoMateria>>($"{BaseUrl}/GetByAlumno/{alumnoId}");
        }

        public async Task<HttpRespuesta<List<CursadoMateria>>> GetByTurno(int turnoId)
        {
            return await _httpServicio.Get<List<CursadoMateria>>($"{BaseUrl}/GetByTurno/{turnoId}");
        }

        public async Task<HttpRespuesta<List<CursadoMateria>>> GetByCondicion(string condicion)
        {
            return await _httpServicio.Get<List<CursadoMateria>>($"{BaseUrl}/GetByCondicion/{condicion}");
        }

        public async Task<HttpRespuesta<List<CursadoMateria>>> GetByAnno(int anno)
        {
            return await _httpServicio.Get<List<CursadoMateria>>($"{BaseUrl}/GetByAnno/{anno}");
        }
    }
}

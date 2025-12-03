using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CUPOF_ProfesorServicio : Servicio<CUPOF_Profesor>, ICUPOF_ProfesorServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/CUPOFProfesores";

        public CUPOF_ProfesorServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByTurno(int turnoId)
        {
            return await _httpServicio.Get<List<CUPOF_Profesor>>($"{BaseUrl}/GetByTurno/{turnoId}");
        }

        public async Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<CUPOF_Profesor>>($"{BaseUrl}/GetByEstado/{estado}");
        }

        public async Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByOcupadoLibre(string estadoOcupacion)
        {
            return await _httpServicio.Get<List<CUPOF_Profesor>>($"{BaseUrl}/GetByOcupadoLibre/{estadoOcupacion}");
        }
    }
}

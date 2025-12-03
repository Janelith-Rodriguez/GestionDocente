using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class PlanEstudioServicio : Servicio<PlanEstudio>, IPlanEstudioServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/PlanesEstudio";

        public PlanEstudioServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<PlanEstudio>> GetByNombre(string nombre)
        {
            return await _httpServicio.Get<PlanEstudio>($"{BaseUrl}/GetByNombre/{nombre}");
        }

        public async Task<HttpRespuesta<List<PlanEstudio>>> GetByCarrera(int carreraId)
        {
            return await _httpServicio.Get<List<PlanEstudio>>($"{BaseUrl}/GetByCarrera/{carreraId}");
        }

        public async Task<HttpRespuesta<List<PlanEstudio>>> GetByAnno(int anno)
        {
            return await _httpServicio.Get<List<PlanEstudio>>($"{BaseUrl}/GetByAnno/{anno}");
        }
    }
}

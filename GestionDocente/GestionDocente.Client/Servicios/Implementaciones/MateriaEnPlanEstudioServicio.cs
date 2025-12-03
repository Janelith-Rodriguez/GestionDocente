using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class MateriaEnPlanEstudioServicio : Servicio<MateriaEnPlanEstudio>, IMateriaEnPlanEstudioServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/MateriasEnPlanEstudio";

        public MateriaEnPlanEstudioServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByPlanEstudio(int planEstudioId)
        {
            return await _httpServicio.Get<List<MateriaEnPlanEstudio>>($"{BaseUrl}/GetByPlan/{planEstudioId}");
        }

        public async Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByMateria(int materiaId)
        {
            return await _httpServicio.Get<List<MateriaEnPlanEstudio>>($"{BaseUrl}/GetByMateria/{materiaId}");
        }

        public async Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByAnno(int anno)
        {
            return await _httpServicio.Get<List<MateriaEnPlanEstudio>>($"{BaseUrl}/GetByAnno/{anno}");
        }
    }
}

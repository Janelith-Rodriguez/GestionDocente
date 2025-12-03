using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CorrelatividadServicio : Servicio<Correlatividad>, ICorrelatividadServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Correlatividades";

        public CorrelatividadServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<Correlatividad>>> GetByMateriaPlan(int materiaPlanId)
        {
            return await _httpServicio.Get<List<Correlatividad>>($"{BaseUrl}/GetByMateria/{materiaPlanId}");
        }

        public async Task<HttpRespuesta<List<Correlatividad>>> GetByMateriaCorrelativa(int materiaCorrelativaId)
        {
            return await _httpServicio.Get<List<Correlatividad>>($"{BaseUrl}/GetByMateriaCorrelativa/{materiaCorrelativaId}");
        }
    }
}
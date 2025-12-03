using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class InscripcionCarreraServicio : Servicio<InscripcionCarrera>, IInscripcionCarreraServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/InscripcionesCarrera";

        public InscripcionCarreraServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<InscripcionCarrera>>> GetByAlumno(int alumnoId)
        {
            return await _httpServicio.Get<List<InscripcionCarrera>>($"{BaseUrl}/GetByAlumno/{alumnoId}");
        }

        public async Task<HttpRespuesta<List<InscripcionCarrera>>> GetByCarrera(int carreraId)
        {
            return await _httpServicio.Get<List<InscripcionCarrera>>($"{BaseUrl}/GetByCarrera/{carreraId}");
        }

        public async Task<HttpRespuesta<List<InscripcionCarrera>>> GetByCohorte(int cohorte)
        {
            return await _httpServicio.Get<List<InscripcionCarrera>>($"{BaseUrl}/GetByCohorte/{cohorte}");
        }

        public async Task<HttpRespuesta<InscripcionCarrera>> GetByLegajo(string legajo)
        {
            return await _httpServicio.Get<InscripcionCarrera>($"{BaseUrl}/GetByLegajo/{legajo}");
        }
    }
}

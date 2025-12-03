using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CoordinadorServicio : Servicio<Coordinador>, ICoordinadorServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Coordinadores";

        public CoordinadorServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Coordinador>> GetByUsuario(int usuarioId)
        {
            return await _httpServicio.Get<Coordinador>($"{BaseUrl}/GetByUsuario/{usuarioId}");
        }

        public async Task<HttpRespuesta<List<Coordinador>>> GetByCarrera(int carreraId)
        {
            return await _httpServicio.Get<List<Coordinador>>($"{BaseUrl}/GetByCarrera/{carreraId}");
        }

        public async Task<HttpRespuesta<List<Coordinador>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<Coordinador>>($"{BaseUrl}/GetByEstado/{estado}");
        }
    }
}

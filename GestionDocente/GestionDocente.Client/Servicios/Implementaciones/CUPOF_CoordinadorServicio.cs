using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CUPOF_CoordinadorServicio : Servicio<CUPOF_Coordinador>, ICUPOF_CoordinadorServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/CUPOFCoordinadores";

        public CUPOF_CoordinadorServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByCarrera(int carreraId)
        {
            return await _httpServicio.Get<List<CUPOF_Coordinador>>($"{BaseUrl}/GetByCarrera/{carreraId}");
        }

        public async Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByCoordinador(int coordinadorId)
        {
            return await _httpServicio.Get<List<CUPOF_Coordinador>>($"{BaseUrl}/GetByCoordinador/{coordinadorId}");
        }

        public async Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByEstado(bool estado)
        {
            return await _httpServicio.Get<List<CUPOF_Coordinador>>($"{BaseUrl}/GetByEstado/{estado}");
        }

        public async Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByOcupadoLibre(string estadoOcupacion)
        {
            return await _httpServicio.Get<List<CUPOF_Coordinador>>($"{BaseUrl}/GetByOcupadoLibre/{estadoOcupacion}");
        }
    }
}

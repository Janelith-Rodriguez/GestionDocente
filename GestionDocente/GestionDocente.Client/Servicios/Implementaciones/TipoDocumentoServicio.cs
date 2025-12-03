using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class TipoDocumentoServicio : Servicio<TipoDocumento>, ITipoDocumentoServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/TipoDocumentos";

        public TipoDocumentoServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<TipoDocumento>> GetByCodigo(string codigo)
        {
            return await _httpServicio.Get<TipoDocumento>($"{BaseUrl}/GetByCod/{codigo}");
        }
    }
}

using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class PersonaServicio : Servicio<Persona>, IPersonaServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Personas";

        public PersonaServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Persona>> GetByDocumento(string documento)
        {
            return await _httpServicio.Get<Persona>($"{BaseUrl}/GetByDocumento/{documento}");
        }

        public async Task<HttpRespuesta<List<Persona>>> GetByTipoDocumento(int tipoDocumentoId)
        {
            return await _httpServicio.Get<List<Persona>>($"{BaseUrl}/GetByTipoDocumento/{tipoDocumentoId}");
        }

        public async Task<HttpRespuesta<List<Persona>>> GetByNombreApellido(string nombre, string apellido)
        {
            return await _httpServicio.Get<List<Persona>>($"{BaseUrl}/GetByNombreApellido/{nombre}/{apellido}");
        }
    }
}

using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class NotaServicio : Servicio<Nota>, INotaServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Notas";

        public NotaServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<List<Nota>>> GetByEvaluacion(int evaluacionId)
        {
            return await _httpServicio.Get<List<Nota>>($"{BaseUrl}/GetByEvaluacion/{evaluacionId}");
        }

        public async Task<HttpRespuesta<List<Nota>>> GetByCursadoMateria(int cursadoMateriaId)
        {
            return await _httpServicio.Get<List<Nota>>($"{BaseUrl}/GetByCursado/{cursadoMateriaId}");
        }

        public async Task<HttpRespuesta<List<Nota>>> GetByValor(int valorNota)
        {
            return await _httpServicio.Get<List<Nota>>($"{BaseUrl}/GetByValor/{valorNota}");
        }
    }
}
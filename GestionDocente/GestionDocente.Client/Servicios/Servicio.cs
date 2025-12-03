using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class Servicio<T> : IServicio<T> where T : class
    {
        private readonly IHttpServicio _httpServicio;

        public Servicio(IHttpServicio httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<T>> Get(string url)
        {
            return await _httpServicio.Get<T>(url);
        }

        public async Task<HttpRespuesta<T>> GetById(string url, int id)
        {
            return await _httpServicio.Get<T>($"{url}/{id}");
        }

        public async Task<HttpRespuesta<List<T>>> GetAll(string url)
        {
            return await _httpServicio.Get<List<T>>(url);
        }

        public async Task<HttpRespuesta<object>> Post(string url, T entidad)
        {
            return await _httpServicio.Post(url, entidad);
        }

        public async Task<HttpRespuesta<object>> Put(string url, T entidad)
        {
            return await _httpServicio.Put(url, entidad);
        }

        public async Task<HttpRespuesta<object>> Delete(string url, int id)
        {
            return await _httpServicio.Delete($"{url}/{id}");
        }
    }
}

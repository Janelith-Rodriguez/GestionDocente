using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public interface IServicio<T> where T : class
    {
        Task<HttpRespuesta<T>> Get(string url);
        Task<HttpRespuesta<T>> GetById(string url, int id);
        Task<HttpRespuesta<List<T>>> GetAll(string url);
        Task<HttpRespuesta<object>> Post(string url, T entidad);
        Task<HttpRespuesta<object>> Put(string url, T entidad);
        Task<HttpRespuesta<object>> Delete(string url, int id);
    }
}

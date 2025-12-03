using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class CarreraServicio : Servicio<Carrera>, ICarreraServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Carreras";

        public CarreraServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Carrera>> GetByNombre(string nombre)
        {
            return await _httpServicio.Get<Carrera>($"{BaseUrl}/GetByNombre/{nombre}");
        }
    }
}

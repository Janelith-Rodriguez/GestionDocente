using GestionDocente.BD.Data.Entity;
using GestionDocente.Client.Servicios;

namespace GestionDocente.Client.Servicios
{
    public class MateriaServicio : Servicio<Materia>, IMateriaServicio
    {
        private readonly IHttpServicio _httpServicio;
        private const string BaseUrl = "api/Materias";

        public MateriaServicio(IHttpServicio httpServicio) : base(httpServicio)
        {
            _httpServicio = httpServicio;
        }

        public async Task<HttpRespuesta<Materia>> GetByNombre(string nombre)
        {
            return await _httpServicio.Get<Materia>($"{BaseUrl}/GetByNombre/{nombre}");
        }

        public async Task<HttpRespuesta<List<Materia>>> GetByFormacion(string formacion)
        {
            return await _httpServicio.Get<List<Materia>>($"{BaseUrl}/GetByFormacion/{formacion}");
        }
    }
}

using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IAlumnoServicio : IServicio<Alumno>
    {
        Task<HttpRespuesta<Alumno>> GetByUsuario(int usuarioId);
        Task<HttpRespuesta<List<Alumno>>> GetByEstado(bool estado);
        Task<HttpRespuesta<List<Alumno>>> GetByPais(string pais);
    }
}
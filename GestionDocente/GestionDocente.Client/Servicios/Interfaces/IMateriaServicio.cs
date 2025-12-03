using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IMateriaServicio : IServicio<Materia>
    {
        Task<HttpRespuesta<Materia>> GetByNombre(string nombre);
        Task<HttpRespuesta<List<Materia>>> GetByFormacion(string formacion);
    }
}
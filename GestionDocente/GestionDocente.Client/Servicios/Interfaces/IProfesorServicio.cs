using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IProfesorServicio : IServicio<Profesor>
    {
        Task<HttpRespuesta<Profesor>> GetByUsuario(int usuarioId);
        Task<HttpRespuesta<List<Profesor>>> GetByEstado(bool estado);
    }
}

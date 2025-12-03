using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IProfesorRepositorio : IRepositorio<Profesor>
    {
        Task<Profesor> SelectByUsuario(int usuarioId);
        Task<List<Profesor>> SelectByEstado(bool estado);
    }
}

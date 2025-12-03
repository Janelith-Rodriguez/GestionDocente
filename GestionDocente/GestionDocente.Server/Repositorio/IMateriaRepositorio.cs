using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IMateriaRepositorio : IRepositorio<Materia>
    {
        Task<Materia> SelectByNombre(string nombre);
        Task<List<Materia>> SelectByFormacion(string formacion);
    }
}

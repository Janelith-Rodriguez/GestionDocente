using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Repositorio
{
    public interface ICursadoMateriaRepositorio : IRepositorio<CursadoMateria>
    {
        Task<List<CursadoMateria>> FullGetAll();
        Task<CursadoMateria> FullGetById(int id);
    }
}
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICursadoMateriaRepositorio : IRepositorio<CursadoMateria>
    {
        Task<List<CursadoMateria>> FullGetAll();
        Task<CursadoMateria> FullGetById(int id);
    }
}
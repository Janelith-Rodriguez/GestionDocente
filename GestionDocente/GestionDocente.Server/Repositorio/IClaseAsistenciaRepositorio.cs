using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IClaseAsistenciaRepositorio : IRepositorio<ClaseAsistencia>
    {
        Task<List<ClaseAsistencia>> SelectByClase(int claseId);
        Task<List<ClaseAsistencia>> SelectByCursadoMateria(int cursadoMateriaId);
        Task<List<ClaseAsistencia>> SelectByAsistencia(char asistencia);
    }
}

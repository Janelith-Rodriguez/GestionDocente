using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICUPOF_ProfesorRepositorio : IRepositorio<CUPOF_Profesor>
    {
        Task<List<CUPOF_Profesor>> SelectByTurno(int turnoId);
        Task<List<CUPOF_Profesor>> SelectByEstado(bool estado);
        Task<List<CUPOF_Profesor>> SelectByOcupadoLibre(string estadoOcupacion);
    }
}

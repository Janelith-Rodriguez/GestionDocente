using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICUPOF_CoordinadorRepositorio : IRepositorio<CUPOF_Coordinador>
    {
        Task<List<CUPOF_Coordinador>> SelectByCarrera(int carreraId);
        Task<List<CUPOF_Coordinador>> SelectByCoordinador(int coordinadorId);
        Task<List<CUPOF_Coordinador>> SelectByEstado(bool estado);
        Task<List<CUPOF_Coordinador>> SelectByOcupadoLibre(string estadoOcupacion);
    }
}

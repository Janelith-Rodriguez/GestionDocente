using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IPlanEstudioRepositorio : IRepositorio<PlanEstudio>
    {
        Task<PlanEstudio> SelectByNombre(string nombre);
        Task<List<PlanEstudio>> SelectByCarrera(int carreraId);
        Task<List<PlanEstudio>> SelectByAnno(int anno);
    }
}

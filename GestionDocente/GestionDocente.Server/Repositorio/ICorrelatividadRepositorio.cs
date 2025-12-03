using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICorrelatividadRepositorio : IRepositorio<Correlatividad>
    {
        Task<List<Correlatividad>> SelectByMateriaPlan(int materiaPlanId);
        Task<List<Correlatividad>> SelectByMateriaCorrelativa(int materiaCorrelativaId);
    }
}
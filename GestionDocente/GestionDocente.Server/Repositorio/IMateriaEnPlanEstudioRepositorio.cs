using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IMateriaEnPlanEstudioRepositorio : IRepositorio<MateriaEnPlanEstudio>
    {
        Task<List<MateriaEnPlanEstudio>> SelectByPlanEstudio(int planEstudioId);
        Task<List<MateriaEnPlanEstudio>> SelectByMateria(int materiaId);
        Task<List<MateriaEnPlanEstudio>> SelectByAnno(int anno);
    }
}

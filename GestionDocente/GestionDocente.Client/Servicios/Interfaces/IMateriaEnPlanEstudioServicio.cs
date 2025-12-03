using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IMateriaEnPlanEstudioServicio : IServicio<MateriaEnPlanEstudio>
    {
        Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByPlanEstudio(int planEstudioId);
        Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByMateria(int materiaId);
        Task<HttpRespuesta<List<MateriaEnPlanEstudio>>> GetByAnno(int anno);
    }
}
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IPlanEstudioServicio : IServicio<PlanEstudio>
    {
        Task<HttpRespuesta<PlanEstudio>> GetByNombre(string nombre);
        Task<HttpRespuesta<List<PlanEstudio>>> GetByCarrera(int carreraId);
        Task<HttpRespuesta<List<PlanEstudio>>> GetByAnno(int anno);
    }
}

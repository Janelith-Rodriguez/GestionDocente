using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICorrelatividadServicio : IServicio<Correlatividad>
    {
        Task<HttpRespuesta<List<Correlatividad>>> GetByMateriaPlan(int materiaPlanId);
        Task<HttpRespuesta<List<Correlatividad>>> GetByMateriaCorrelativa(int materiaCorrelativaId);
    }
}

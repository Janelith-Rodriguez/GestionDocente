using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface INotaRepositorio : IRepositorio<Nota>
    {
        Task<List<Nota>> SelectByEvaluacion(int evaluacionId);
        Task<List<Nota>> SelectByCursadoMateria(int cursadoMateriaId);
        Task<List<Nota>> SelectByValor(int valorNota);
    }
}
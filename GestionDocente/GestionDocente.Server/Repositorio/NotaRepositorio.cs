using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class NotaRepositorio : Repositorio<Nota>, INotaRepositorio
    {
        private readonly Context context;

        public NotaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Nota>> SelectByEvaluacion(int evaluacionId)
        {
            return await context.Notas
                .Include(n => n.Evaluacion)
                .Include(n => n.CursadoMateria)
                .AsNoTracking()
                .Where(x => x.EvaluacionId == evaluacionId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Nota>> SelectByCursadoMateria(int cursadoMateriaId)
        {
            return await context.Notas
                .Include(n => n.Evaluacion)
                .AsNoTracking()
                .Where(x => x.CursadoMateriaId == cursadoMateriaId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Nota>> SelectByValor(int valorNota)
        {
            return await context.Notas
                .Include(n => n.Evaluacion)
                .Include(n => n.CursadoMateria)
                .AsNoTracking()
                .Where(x => x.ValorNota == valorNota && x.Activo)
                .ToListAsync();
        }
    }
}

using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        //____________________________________________________________________________________________
        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id && x.Activo);
            return existe;
        }
        //____________________________________________________________________________________________
        public async Task<List<E>> Select()
        {
            return await context.Set<E>()
                .Where(x => x.Activo)
                .ToListAsync();
        }
        //____________________________________________________________________________________________
        public async Task<E> SelectById(int id)
        {
            E? entidad = await context.Set<E>()
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id && x.Activo);
            return entidad;
        }
        //____________________________________________________________________________________________
        public async Task<int> Insert(E entidad)
        {
            try
            {
                // Asegurar que la entidad tenga Activo = true
                entidad.Activo = true;

                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al insertar: {dbEx.InnerException?.Message ?? dbEx.Message}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al insertar: {ex.Message}", ex);
            }
        }
        //____________________________________________________________________________________
        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }

            var entidadExistente = await context.Set<E>()
                .FirstOrDefaultAsync(x => x.Id == id && x.Activo);

            if (entidadExistente == null)
            {
                return false;
            }

            try
            {
                // Actualizar propiedades excepto el Id
                context.Entry(entidadExistente).CurrentValues.SetValues(entidad);
                // Mantener el Activo como estaba
                entidadExistente.Activo = true;

                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al actualizar: {dbEx.InnerException?.Message ?? dbEx.Message}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar: {ex.Message}", ex);
            }
        }
        //____________________________________________________________________________________________
        public async Task<bool> Delete(int id)
        {
            var entidad = await context.Set<E>()
                .FirstOrDefaultAsync(x => x.Id == id && x.Activo);

            if (entidad == null)
            {
                return false;
            }

            try
            {
                // Soft delete - marcar como inactivo en lugar de eliminar físicamente
                entidad.Activo = false;
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al eliminar: {dbEx.InnerException?.Message ?? dbEx.Message}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar: {ex.Message}", ex);
            }
        }

        //____________________________________________________________________________________________
        // Método adicional para eliminación física (si es necesaria)
        public async Task<bool> DeleteFisico(int id)
        {
            var entidad = await context.Set<E>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Remove(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al eliminar físicamente: {dbEx.InnerException?.Message ?? dbEx.Message}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar físicamente: {ex.Message}", ex);
            }
        }
    }
}

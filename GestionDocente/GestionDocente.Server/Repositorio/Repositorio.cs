﻿using GestionDocente.BD.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;

namespace GestionDocente.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> 
                 where E : class, IEntityBase
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
                             .AnyAsync(x => x.Id == id);
            return existe;
        }
        //____________________________________________________________________________________________
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }
        //____________________________________________________________________________________________
        public async Task<E> SelectById(int id)
        {
            E? d = await context.Set<E>()
               .AsNoTracking()
               .FirstOrDefaultAsync(
                x => x.Id == id);
            return d;
        }
        //____________________________________________________________________________________________
        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }

            catch (Exception err)
            {
                throw err;
            }
        }
        //____________________________________________________________________________________
        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var d = await SelectById(id);

            if (d == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //____________________________________________________________________________________________
        public async Task<bool> Delete(int id)
        {
            //try
            //{
            // Buscar la entidad por su ID
            var d = await SelectById(id);

            if (d == null)
            {
                // Si la entidad no existe, retornar false
                return false;
            }

            // Eliminar la entidad del contexto
            context.Set<E>().Remove(d);

            // Intentar guardar los cambios en la base de datos
            await context.SaveChangesAsync();

            return true;
            //}
            //catch (DbUpdateException ex)
            //{
            //    // Si ocurre una excepción al guardar los cambios, loguearla
            //    // Esto es común cuando hay violación de restricciones de base de datos como claves foráneas
            //    Console.WriteLine($"Error al eliminar la entidad: {ex.Message}");
            //    if (ex.InnerException != null)
            //    {
            //        Console.WriteLine($"Excepción interna: {ex.InnerException.Message}");
            //    }

            //    // Retornar false si ocurre un error
            //    return false;
            //}
            //catch (Exception ex)
            //{
            //    // Captura cualquier otra excepción que pueda ocurrir
            //    Console.WriteLine($"Error inesperado: {ex.Message}");
            //    return false;
            //}
        }
    }
}
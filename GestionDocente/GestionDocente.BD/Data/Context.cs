using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<CertificadoAlumno> CertificadosAlumnos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseAsistencia> ClasesAsistencias { get; set; }
        public DbSet<Coordinador> Coordinadores { get; set; }
        public DbSet<Correlatividad> Correlatividades { get; set; }
        public DbSet<CUPOF_Coordinador> CUPOF_Coordinadores { get; set; }
        public DbSet<CUPOF_Profesor> CUPOF_Profesores { get; set; }
    

        public DbSet<CursadoMateria> CursadosMateria { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<InscripcionCarrera> InscripcionCarreras { get; set; }
        public DbSet<MAB> MAB { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaEnPlanEstudio> MateriasEnPlanEstudio { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PlanEstudio> PlanEstudios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Éste codigo sirve para evitar que se borren los datos en cascada en la base de datos
            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                            .SelectMany(t => t.GetForeignKeys())
                                            .Where(fk => !fk.IsOwnership
                                                        && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {        //Elimina el borrado en cascada               
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }

}

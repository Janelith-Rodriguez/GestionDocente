using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(ClaseId), Name = "AsistenciasDeUnaClaseIDX", IsUnique = false)]
    [Index(nameof(Asistencia), nameof(ClaseId), Name = "FaltaronEstaClaseIDX", IsUnique = false)]
    [Index(nameof(CursadoMateriaId), Name = "AsistenciasDeAlumnoEnTurnoIDX", IsUnique = false)]
    public class ClaseAsistencia : EntityBase
    {
        public int CursadoMateriaId { get; set; }
        public CursadoMateria CursadoMateria { get; set; }



        public int ClaseId { get; set; }
        public Clase Clase { get; set; }

        [Required(ErrorMessage = "La asistencia del alumno es obligatoria")]
        public char Asistencia { get; set; }


        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Observacion { get; set; }
    }
}

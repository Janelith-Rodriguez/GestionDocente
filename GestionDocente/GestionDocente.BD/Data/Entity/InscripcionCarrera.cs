using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(AlumnoId), nameof(CarreraId), nameof(Cohorte), Name = "InscripcionCarrera_UQ", IsUnique = true)]
    [Index(nameof(CarreraId), nameof(Cohorte), Name = "CohorteIDX", IsUnique = false)]
    public class InscripcionCarrera : EntityBase
    {
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        [Required(ErrorMessage = "La carrera es obligatorio")]

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        [Required(ErrorMessage = "El ID de la carrera es obligatorio")]
        public int Cohorte { get; set; }

        [Required(ErrorMessage = "El legajo es necesario")]
        [MaxLength(12, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Legajo { get; set; }

        [Required(ErrorMessage = "El Estado del alumno es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string EstadoAlumno { get; set; }

        [Required(ErrorMessage = "El libro matriz del alumno es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string LibroMatriz { get; set; }

        [Required(ErrorMessage = "El número de orden del alumno es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string NroOrdenAlumno { get; set; }
    }
}

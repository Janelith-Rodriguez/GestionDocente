using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearInscripcionCarreraDTO
    {
        [Required(ErrorMessage = "El alumno es obligatorio")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria")]
        public int CarreraId { get; set; }

        [Required(ErrorMessage = "El cohorte es obligatorio")]
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

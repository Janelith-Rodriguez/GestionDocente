
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Shared.DTO
{
    public class CrearCursadoMateriaDTO
    {
        [Required(ErrorMessage = "El alumno es obligatorio")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "El turno es obligatorio")]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria")]
        public DateTime FechaInscripcion { get; set; }

        [Required(ErrorMessage = "El año de cursado es obligatorio")]
        public int Anno { get; set; }

        [Required(ErrorMessage = "La condición actual es obligatoria")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CondicionActual { get; set; }

        public DateTime? VencimientoCondicion { get; set; }
    }
}

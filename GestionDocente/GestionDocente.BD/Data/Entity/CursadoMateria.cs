using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class CursadoMateria : EntityBase
    {
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }


        public int TurnoId { get; set; } //Este es el turno de la materia a la que el alumno va, por las dudas. Ponele Modelado Sistamas, pero el de turno mañana, que es donde esta Algorry.
        public Turno Turno { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción en la materia es obligatoria")]
        public DateTime FechaInscripcion { get; set; }

        [Required(ErrorMessage = "El año de cursado de la materia es obligatoria")]
        public int Anno { get; set; }  //Año de cursado actualmente por el alumno

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CondicionActual { get; set; } //libre, regular, promocionado

        public DateTime? VencimientoCondicion { get; set; } //Fecha en que vence la 'CondicionAcutal'. Las regularizaciones tienen vencimiento, por las dudas.

        public List<Nota>? Notas { get; set; } = new List<Nota>();
        public List<ClaseAsistencia>? ClaseAsistencias { get; set; } = new List<ClaseAsistencia>();
    }
}

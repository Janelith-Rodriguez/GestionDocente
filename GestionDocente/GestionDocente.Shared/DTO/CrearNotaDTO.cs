using GestionDocente.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearNotaDTO
    {
        [Required(ErrorMessage = "La evaluación es obligatoria")]
        public int EvaluacionId { get; set; }

        [Required(ErrorMessage = "El valor de la nota es obligatoria")]
        public int ValorNota { get; set; }

        [Required(ErrorMessage = "La asistencia es obligatoria")]
        public char Asistencia { get; set; }

        [Required(ErrorMessage = "El cursado de materia es obligatorio")]
        public int CursadoMateriaId { get; set; }
    }
}

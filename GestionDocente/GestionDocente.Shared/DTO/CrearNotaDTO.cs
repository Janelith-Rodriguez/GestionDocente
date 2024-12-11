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
        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; }

        [Required(ErrorMessage = "El valor de la nota es obligatoria")]
        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public int ValorNota { get; set; }

        [Required(ErrorMessage = "La aistencia es obligatoria")]
        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public char Asistencia { get; set; }

        public int CursadoMateriaId { get; set; }
        public CursadoMateria CursadoMateria { get; set; }
    }
}

using GestionDocente.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearEvaluacionDTO
    {
        [Required(ErrorMessage = "El turno es obligatorio")]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de evaluación es obligatorio")]
        [MaxLength(36, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string TipoEvaluacion { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Folio { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Libro { get; set; }

        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Sede { get; set; }

    }
}

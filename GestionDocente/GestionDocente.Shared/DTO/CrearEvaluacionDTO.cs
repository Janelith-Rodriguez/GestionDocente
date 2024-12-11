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
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de la evaluacion es obligatorio")]
        [MaxLength(36, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string TipoEvaluacion { get; set; } //Parcial, Final, IEFI, recuperatorio, etc.

        [Required(ErrorMessage = "El folio es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Folio { get; set; } //

        [Required(ErrorMessage = "El libro es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Libro { get; set; } //

        [Required(ErrorMessage = "La se de es obligatoria")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Sede { get; set; }

    }
}

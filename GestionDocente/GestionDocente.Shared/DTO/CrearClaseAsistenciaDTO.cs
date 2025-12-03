using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearClaseAsistenciaDTO
    {
        [Required(ErrorMessage = "El cursado de materia es obligatorio")]
        public int CursadoMateriaId { get; set; }

        [Required(ErrorMessage = "La clase es obligatoria")]
        public int ClaseId { get; set; }

        [Required(ErrorMessage = "La asistencia del alumno es obligatoria")]
        public char Asistencia { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Observacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearAlumnoDTO
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo edad es obligatorio")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El Cuil es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? CUIL { get; set; }

        [Required(ErrorMessage = "El campo nacionalidad es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo provincia es obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Provincia { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Departamento { get; set; }

        [Required(ErrorMessage = "El campo titulo es obligatorio")]
        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? TituloBase { get; set; }

        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? FotocopiaDNI { get; set; }

        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? ConstanciaCUIL { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? PartidaNacimiento { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Analitico { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? FotoCarnet { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? CUS { get; set; }
    }
}

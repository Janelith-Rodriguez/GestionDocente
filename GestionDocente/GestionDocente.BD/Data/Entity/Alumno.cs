using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class Alumno : EntityBase
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sexo { get; set; }


        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo edad es obligatorio")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}.")]
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

        [Required(ErrorMessage = "Dato obligatorio")]
        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? FotocopiaDNI { get; set; }

        [Required(ErrorMessage = "El campo constancia es obligatorio")]
        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? ConstanciaCUIL { get; set; } //esto es para indicar que el alumno trajo o mandó un documento virtual de la constancia de CUIL, no tiene que ver con el atributo "CUIL", el cual es el cuil real.

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? PartidaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Analitico { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? FotoCarnet { get; set; }

        [Required(ErrorMessage = "Dato obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? CUS { get; set; }

        public bool Estado { get; set; } = true; //si está activo o no el alumno, para bloquear o dar acceso
                                                 //al usuario en su calidad de alumno
        public List<CertificadoAlumno> CertificadosAlumno { get; set; } = new List<CertificadoAlumno>();
        public List<CursadoMateria> MateriasCursadas { get; set; } = new List<CursadoMateria>();
        public List<InscripcionCarrera> InscripcionesCarreras { get; set; } = new List<InscripcionCarrera>();
    }
}

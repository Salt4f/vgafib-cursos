using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGAFIBCursos.Models
{
    public class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string? Dni { get; set; }

        [ForeignKey(nameof(Curso))]
        [HiddenInput]
        public int? CursoId { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? NombreCompanero { get; set; }

        public bool Fiber { get; set; }

        public DateTime? FechaInscripcion { get; set; }

        public Curso? Curso { get; set; }
        
        /*
         Nombre
         Apellidos
         DNI
         E-mail
         Nombre de compañero
         Fiber?
         */
    }
}

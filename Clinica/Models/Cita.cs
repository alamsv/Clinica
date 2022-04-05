using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public int IdDoctor { get; set; }
        [Required]
        public int IdPaciente { get; set; }
    }
}

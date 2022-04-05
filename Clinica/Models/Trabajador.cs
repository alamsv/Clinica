using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
    }
}

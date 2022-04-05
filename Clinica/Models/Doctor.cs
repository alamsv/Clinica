using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTrabajador { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
    }
}

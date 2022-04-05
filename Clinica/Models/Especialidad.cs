using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreEspecialidad { get; set; }
    }
}

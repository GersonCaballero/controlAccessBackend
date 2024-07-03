using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]

        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(500)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

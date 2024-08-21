using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAccess.Models
{
    public class Avenidas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string name { get; set; }

        [Required]       
        public int ResidencialId { get; set; }

        [ForeignKey("ResidencialId")]
        public Residencial? Residencial { get; set; }


        // Campos de auditoría
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

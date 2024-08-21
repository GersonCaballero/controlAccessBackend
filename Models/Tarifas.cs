using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Tarifas
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [ForeignKey("Inmuebles")]
        public int IdTipoInmueble { get; set; }
        [ForeignKey("IdTipoInmueble") ]
        public Inmuebles? Inmuebles { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        // Campos de auditoría        
        public string? CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

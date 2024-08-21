    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Accesos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public int? UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuarios? Usuario { get; set; }

        public int? VisitanteId { get; set; }
        [ForeignKey(nameof(VisitanteId))]
        public Visitantes? Visitante { get; set; }

        [StringLength(50)]
        public string TipoAcceso { get; set; } // Entrada, Salida.

        public int? VehiculoId { get; set; }
        [ForeignKey(nameof(VehiculoId))]
        public Vehiculos? Vehiculo { get; set; }

        public int? CasaId { get; set; }
        [ForeignKey(nameof(CasaId))]
        public Casas? Casa { get; set; }        

        // Campos de auditoría
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

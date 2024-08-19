using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Reportes
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string TipoReporte { get; set; } // Acceso, Incidencia

        public DateTime FechaHoraGeneracion { get; set; }

        [StringLength(1000)]
        public string Contenido { get; set; } // Detalles del reporte

        public int? UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuarios? Usuario { get; set; }

        // Campos de auditoría
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

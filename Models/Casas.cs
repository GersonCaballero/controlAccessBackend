using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAccess.Models
{
    public class Casas
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [StringLength(500)]
        public string name { get; set; }
        [Required]

        // Nuevos campos de relación
        public int? IdZona { get; set; }
        [ForeignKey("IdZona")]
        public Zonas? Zona { get; set; }

        public int IdBloque { get; set; }
        [ForeignKey("IdBloque")]
        public Bloque? Bloque { get; set; }

        public int IdCalle { get; set; }
        [ForeignKey("IdCalle")]
        public Calles? Calle { get; set; }

        public int IdAvenida { get; set; }
        [ForeignKey("IdAvenida")]
        public Avenidas? Avenidas { get; set; }

        // Campos de auditoría
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Incidencias
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Descripcion { get; set; }

        [Required, StringLength(50)]
        public string Estado { get; set; } // Resuelto, Pendiente, etc.

        [Required, StringLength(50)]
        public string Tipo { get; set; } // Robo, Queja, Carro extraño, etc.

        public int? UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuarios? Usuario { get; set; }

        public int? CasaId { get; set; }

        [ForeignKey(nameof(CasaId))]
        public Casas? Casa { get; set; }

        // Campos de auditoría
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Vehiculos 
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Placa { get; set; }

        [Required, StringLength(50)]
        public string Marca { get; set; }

        [Required, StringLength(50)]
        public string Modelo { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

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

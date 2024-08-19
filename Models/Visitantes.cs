using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Visitantes
    {

        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Required, StringLength(20)]
        public string NumeroIdentidad { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; }  

        [Required, StringLength(500)]
        public string? Observaciones { get; set; }

        // Campos de auditoría
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}

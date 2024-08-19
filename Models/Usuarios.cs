using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAccess.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(500)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroCelular { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(50)] 
        public string Contrasena { get; set; }

        // Campos relacionados
        [Required]
        public int IdTipoDeUsuario { get; set; }

        [ForeignKey("IdTipoDeUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }

        public int? IdCasa { get; set; }

        [ForeignKey("IdCasa")]
        public Casas? Casas { get; set; }

        public int? IdInmueble { get; set; }

        [ForeignKey("IdInmueble")]
        public Inmuebles? Inmuebles { get; set; }

        // Campos de auditoría
      
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

       
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

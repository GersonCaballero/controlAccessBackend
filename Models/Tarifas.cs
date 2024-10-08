﻿using System.ComponentModel.DataAnnotations.Schema;
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
        public Inmuebles Inmuebles { get; set; }

        [Required]
        public decimal Monto { get; set; }

        // Campos de auditoría
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

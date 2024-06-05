using System.ComponentModel.DataAnnotations;

namespace ControlAccess.Models
{
    public class Residencial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string name { get; set; }
        [Required]
        [StringLength(500)]
        public string address { get; set; }

        [StringLength(1500)]
        public string imageUrl { get; set; }
    }
}

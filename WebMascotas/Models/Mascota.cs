using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebMascotas.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "De entrada a Nombre de la Mascota")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de su Mascota")]
        [MaxLength(50)]

        public string? Nombre { get; set; }

        public DateTime FechaRegistr { get; set; }

        public bool Pedigri { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Seleccione una Raza")]
        [DataType(DataType.Text)]
        public Razas? Raza { get; set; }

        [Required(ErrorMessage = "De entrada a un correo electrónico")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string? EmailResponsable { get; set; }

    }
}

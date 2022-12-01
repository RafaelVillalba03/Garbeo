using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Garbeo.Models
{
    public class Contacto
    {
        [BindNever]
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "Introduce tu nombre")]
        [Display(Name = "Nombre")]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Introduce tu apellido")]
        [Display(Name = "Apellido")]
        [StringLength(40)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Introduce tu email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduce tu número de teléfono")]
        [Display(Name = "Número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(9)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Introduce tu número de teléfono")]
        [Display(Name = "Número máx. de caracteres 200")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [MinLength(50)]
        public string TextArea { get; set; }

    }
}

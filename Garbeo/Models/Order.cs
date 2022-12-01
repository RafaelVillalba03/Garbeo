using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Garbeo.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage = "Introduce tu nombre")]
        [Display(Name = "Nombre")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Introduce tu apellido")]
        [Display(Name = "Apellido")]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Introduce la dirección de envío")]
        [Display(Name = "Dirección de envío")]
        [StringLength(80)]
        public string Adress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Introduce el código postal")]
        [Display(Name = "C.P.")]
        [StringLength(5)]
        public string ZipCode { get; set; } = string.Empty ;

        [Required(ErrorMessage = "Introduce la ciudad de envío")]
        [Display(Name = "Ciudad")]
        [StringLength(20)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Introduce tu email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Introduce tu número de teléfono")]
        [Display(Name = "Número de teléfono")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(9)]
        public string PhoneNumber { get; set; } = string.Empty;

        public decimal TotalOrder { get; set; }
        public DateTime OrderPlaced { get; set; }

    }
}

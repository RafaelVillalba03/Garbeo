using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Models
{
    public class Camiseta
    {
        public int CamisetaId { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }
        public string? ImagenUrl { get; set; }

    }
}
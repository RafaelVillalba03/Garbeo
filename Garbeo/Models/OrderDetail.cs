namespace Garbeo.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CamisetaId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Camiseta Camiseta { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}

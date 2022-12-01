namespace Garbeo.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Camiseta Camiseta { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; } //FK    
    }
}

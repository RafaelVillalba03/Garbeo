namespace Garbeo.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Camiseta camiseta);
        int RemoveFromCart(Camiseta camiseta);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

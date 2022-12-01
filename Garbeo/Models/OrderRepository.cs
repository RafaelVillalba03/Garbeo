namespace Garbeo.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly GarbeoDbContext _garbeoDbContext;

        public OrderRepository(IShoppingCart shoppingCart, GarbeoDbContext garbeoDbContext)
        {
            _shoppingCart = shoppingCart;
            _garbeoDbContext = garbeoDbContext;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.TotalOrder = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    CamisetaId = shoppingCartItem.Camiseta.CamisetaId,
                    Price = shoppingCartItem.Camiseta.Precio
                };

                order.OrderDetails.Add(orderDetail);
            }

            _garbeoDbContext.Orders.Add(order);
            _garbeoDbContext.SaveChanges();
        }
    }
}

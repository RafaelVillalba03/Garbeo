using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace Garbeo.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly GarbeoDbContext _garbeoDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(GarbeoDbContext bethanysPieShopDbContext)
        {
            _garbeoDbContext = bethanysPieShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            GarbeoDbContext context = services.GetService<GarbeoDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Camiseta pie)
        {
            var shoppingCartItem =
                    _garbeoDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Camiseta.CamisetaId == pie.CamisetaId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Camiseta = pie,
                    Amount = 1
                };

                _garbeoDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _garbeoDbContext.SaveChanges();
        }

        public int RemoveFromCart(Camiseta pie)
        {
            var shoppingCartItem =
                    _garbeoDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Camiseta.CamisetaId == pie.CamisetaId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _garbeoDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _garbeoDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _garbeoDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Camiseta)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _garbeoDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _garbeoDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _garbeoDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _garbeoDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Camiseta.Precio * c.Amount).Sum();
            return total;
        }
    }
}

using Garbeo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Tu carrito está vacío. Añade algunos artículos.");
            }
            
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View();
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "¡Gracias! Tu pedido está en camino.";
            return View();
        }
    }
}

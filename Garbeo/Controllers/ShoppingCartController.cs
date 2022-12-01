using Garbeo.Models;
using Garbeo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICamisetaRepository _camisetaRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(ICamisetaRepository camisetaRepository, IShoppingCart shoppingCart)
        {
            _camisetaRepository = camisetaRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int camisetaId)
        {
            var selectedCamiseta = _camisetaRepository.AllCamisetas.FirstOrDefault(p => p.CamisetaId == camisetaId);

            if(selectedCamiseta != null)
            {
                _shoppingCart.AddToCart(selectedCamiseta);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int camisetaId)
        {
            var selectedCamiseta = _camisetaRepository.AllCamisetas.FirstOrDefault(p => p.CamisetaId == camisetaId);

            if (selectedCamiseta != null)
            {
                _shoppingCart.RemoveFromCart(selectedCamiseta);
            }
            return RedirectToAction("Index");
        }
    }
}

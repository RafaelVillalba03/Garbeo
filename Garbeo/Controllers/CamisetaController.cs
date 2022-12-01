using Garbeo.Models;
using Garbeo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Controllers
{
    public class CamisetaController : Controller
    {
        private readonly ICamisetaRepository _camisetaRepository;
        public CamisetaController(ICamisetaRepository camisetaRepository)
        {
            _camisetaRepository = camisetaRepository;
        }

        public IActionResult List()
        {
            CamisetaListViewModel camisetasListViewModel = new CamisetaListViewModel(_camisetaRepository.AllCamisetas);
            return View(camisetasListViewModel);
        }

        public IActionResult Details(int id)
        {
            var camiseta = _camisetaRepository.GetCamisetaById(id);
            if (camiseta == null)
                return NotFound();
            return View(camiseta);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
using Garbeo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoRepository _contactoRepository;
       
        public ContactoController(IContactoRepository contactoRepository)
        {
            _contactoRepository = contactoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto(Contacto contacto)
        {

            if (ModelState.IsValid)
            {
                _contactoRepository.CreateContacto(contacto);
                return RedirectToAction("ContactoCompleted");
            }

            return View();
        }

        public IActionResult ContactoCompleted()
        {
            ViewBag.ContactoCompletedMessage = "¡Gracias por tu respuesta! En breve nos pondremos en contacto";
            return View();
        }
    }
}

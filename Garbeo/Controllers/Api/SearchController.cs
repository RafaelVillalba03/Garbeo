using Garbeo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garbeo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICamisetaRepository _camisetaRepository;

        public SearchController(ICamisetaRepository camisetaRepository)
        {
            _camisetaRepository = camisetaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_camisetaRepository.AllCamisetas);
        }

    }
}

using Garbeo.Models;

namespace Garbeo.ViewModels
{
    public class CamisetaListViewModel
    {
        public IEnumerable<Camiseta> Camisetas { get; }

        public CamisetaListViewModel(IEnumerable<Camiseta> camisetas)
        {
            Camisetas = camisetas;
        }

    }
}
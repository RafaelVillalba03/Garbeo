using Microsoft.EntityFrameworkCore;

namespace Garbeo.Models
{
    public class CamisetaRepository : ICamisetaRepository
    {
        private readonly GarbeoDbContext _garbeoDbContext;

        public CamisetaRepository(GarbeoDbContext garbeoDbContext)
        {
            _garbeoDbContext = garbeoDbContext;
        }

        public IEnumerable<Camiseta> AllCamisetas
        {
            get
            {
                return _garbeoDbContext.Camisetas;
            }
        }

        public Camiseta? GetCamisetaById(int camisetaId)
        {
            return _garbeoDbContext.Camisetas.FirstOrDefault(c => c.CamisetaId == camisetaId);
        }
    }
}

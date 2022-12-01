namespace Garbeo.Models
{
    public interface ICamisetaRepository
    {
        IEnumerable<Camiseta> AllCamisetas { get; }
        Camiseta? GetCamisetaById(int camisetaId);
    }
}
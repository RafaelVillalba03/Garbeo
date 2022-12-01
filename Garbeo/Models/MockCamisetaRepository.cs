namespace Garbeo.Models
{
    public class MockCamisetaRepository : ICamisetaRepository
    {
        public IEnumerable<Camiseta> AllCamisetas =>

            new List<Camiseta>
            {
                new Camiseta
                {
                    CamisetaId = 1,
                    Nombre = "Málaga - Centro",
                    Descripcion = "Malaga Centro representa ...",
                    Precio = 21.99M,
                    ImagenUrl = "/images/MalagaCentro_blanco.jpeg"
                },

                new Camiseta
                {
                    CamisetaId = 2,
                    Nombre = "Málaga - El Palo",
                    Descripcion = "El Palo representa ....",
                    Precio = 21.99M,
                    ImagenUrl = "/images/MalagaTrinidad_crema.jpeg"
                }
            };





        public Camiseta? GetCamisetaById(int camisetaId)
        {
            return AllCamisetas.FirstOrDefault(p => p.CamisetaId == camisetaId);
        }


    }
}
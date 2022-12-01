namespace Garbeo.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            GarbeoDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GarbeoDbContext>();

            if(!context.Camisetas.Any())
            {
                context.AddRange(
                    new Camiseta { Precio = 21.99M, Nombre = "Málaga - Centro", ImagenUrl = "/images/MalagaCentro_blanco.jpg", Descripcion = "Malaga Centro representa ..." },
                    new Camiseta { Precio = 21.99M, Nombre = "Málaga - Puerto de la Torre", ImagenUrl = "/images/PuertoDeLaTorre_negro.jpg", Descripcion = "El barrio del Puerto de la Torre representa ..." },
                    new Camiseta { Precio = 21.99M, Nombre = "Málaga - Teatinos", ImagenUrl = "/images/MalagaTeatinos_verde.jpg", Descripcion = "Teatinos reresenta ..." },
                    new Camiseta { Precio = 21.99M, Nombre = "Málaga - Trinidad", ImagenUrl = "/images/MalagaTrinidad_crema.jpg", Descripcion = "La Trinidad representa ..." },
                    new Camiseta { Precio = 7.87M, Nombre = "Málaga - Huelin", ImagenUrl = "/images/MalagaHuelin_negro.jpg", Descripcion = "Huelin representa ..." }
                    );
            }

            context.SaveChanges();
        }

    }
}

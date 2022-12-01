using Microsoft.EntityFrameworkCore;

namespace Garbeo.Models
{
    public class GarbeoDbContext : DbContext
    {
        public GarbeoDbContext(DbContextOptions<GarbeoDbContext>
            options) : base(options)
        {

        }

        public DbSet<Camiseta> Camisetas { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
    }
}

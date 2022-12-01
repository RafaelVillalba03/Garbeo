namespace Garbeo.Models
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly GarbeoDbContext _garbeoDbContext;

        public ContactoRepository(GarbeoDbContext garbeoDbContext)
        {
            _garbeoDbContext = garbeoDbContext;
        }

        public void CreateContacto(Contacto contacto)
        {
            _garbeoDbContext.Contactos.Add(contacto);
            _garbeoDbContext.SaveChanges();
        }
    }

}

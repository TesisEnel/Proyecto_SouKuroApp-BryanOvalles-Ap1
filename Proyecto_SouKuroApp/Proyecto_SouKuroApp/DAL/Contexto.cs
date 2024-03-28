using Microsoft.EntityFrameworkCore;

namespace Proyecto_SouKuroApp.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}

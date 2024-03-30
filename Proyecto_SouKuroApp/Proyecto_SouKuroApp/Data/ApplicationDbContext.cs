using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Proyecto_SouKuroApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Compra> compras { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Venta> ventas { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Informe> Informes { get; set; }
        public DbSet<Compras_Detalles> detalleCompras { get; set; }
        public DbSet<Producto_Detalle> producto_Detalles { get; set; }
    }
}

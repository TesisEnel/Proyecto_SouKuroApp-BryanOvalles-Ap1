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

		public DbSet<Centro_de_Pedidos> centro_de_Pedidos { get; set; }

		public DbSet<Centro_Detalle> centro_Detalle { get; set; }

		public DbSet<Reservacion> reservacion { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Producto>().HasData(new List<Producto>()
             {
                  new Producto() {ProductoId = 1 , Nombre = "CocaCola" , Precio =30, Stock = 89},
                  new Producto() {ProductoId = 2 , Nombre = "Pepsi" , Precio =30, Stock = 89},
                  new Producto() {ProductoId = 3 , Nombre = "Jugo Rica" , Precio =70, Stock = 189},
                  new Producto() {ProductoId = 4 , Nombre = "Jugo Mots" , Precio =90, Stock = 69},
                  new Producto() {ProductoId = 5 , Nombre = "Fanta" , Precio =25, Stock = 89},
                  new Producto() {ProductoId = 6 , Nombre = "Hamburguesa" , Precio =300, Stock = 40},
                  new Producto() {ProductoId = 7 , Nombre = "Hot Dog" , Precio =70, Stock = 29},
                  new Producto() {ProductoId = 8 , Nombre = "Pizza" , Precio =270, Stock = 29},
                  new Producto() {ProductoId = 9 , Nombre = "Yaroa" , Precio =200, Stock = 29},
                  new Producto() {ProductoId = 10 , Nombre = "Lays" , Precio =35, Stock = 29},
                  new Producto() {ProductoId = 11 , Nombre = "Doritos" , Precio =30, Stock = 29},
                  new Producto() {ProductoId = 12, Nombre = "Tostitos" , Precio =250, Stock = 29},
                  new Producto() {ProductoId = 13 , Nombre = "Taqueritos" , Precio =20, Stock = 29},
                  new Producto() {ProductoId = 14 , Nombre = "Chokis" , Precio =40, Stock = 29},
                  new Producto() {ProductoId = 15 , Nombre = "Brugal Blanco" , Precio =500, Stock = 29},
                  new Producto() {ProductoId = 16 , Nombre = "Brugal Extra viejo" , Precio =700, Stock = 29},
                  new Producto() {ProductoId = 17 , Nombre = "Cervesa Presidente" , Precio =140, Stock = 29},
                  new Producto() { ProductoId = 18, Nombre = "Corona", Precio = 120, Stock = 29 }
             });

            builder.Entity<Producto_Detalle>().HasData(new List<Producto_Detalle>()
            {
                new Producto_Detalle() {Id =1,ProductoId=1, Categoria = "Bebidas" },
                new Producto_Detalle() { Id =2,ProductoId=6,Categoria ="Comida"},
                new Producto_Detalle() {Id = 3,ProductoId=10, Categoria ="Snacks"},
                new Producto_Detalle() {Id =4, ProductoId=14,Categoria ="Bebidas Alcoholicas"}
            });
        }
    }
}

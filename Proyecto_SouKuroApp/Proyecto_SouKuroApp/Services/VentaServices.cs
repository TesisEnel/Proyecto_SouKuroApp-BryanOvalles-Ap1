using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class VentaServices
    {
        private readonly ApplicationDbContext _contexto;
        public VentaServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int VentaId)
        {
            return await _contexto.ventas.AnyAsync(c => c.VentaId == VentaId);
        }
        /* public async Task<Usuario?> GetCompras(int id)
         {
             return await _contexto.usuarios.Include(c => c.Detalle).FirstOrDefaultAsync(c => c.CompraId == id);
         }*/
        public async Task<bool> Insertar(Venta venta)
        {
            _contexto.ventas.Add(venta);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Venta venta)
        {
            var c = await _contexto.ventas.FindAsync(venta.VentaId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(venta).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Venta venta)
        {
            if (!await Existe(venta.VentaId))
                return await Insertar(venta);
            else
                return await Modificar(venta);
        }
        public async Task<bool> Eliminar(Venta venta)
        {
            var c = await _contexto.Informes.FindAsync(venta.VentaId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(venta).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Venta?> Buscar(int venta)
        {
            return await _contexto.ventas
                .Where(c => c.VentaId == venta)
                .AsNoTracking()
                .SingleOrDefaultAsync();
            //.Include(c => c.ComprasDetalle)
        }
        public async Task<List<Venta>> Listar(Expression<Func<Venta, bool>> Criterio)
        {
            return await _contexto.ventas
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

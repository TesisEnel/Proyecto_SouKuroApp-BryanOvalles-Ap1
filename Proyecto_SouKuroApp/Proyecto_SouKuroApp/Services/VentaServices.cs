using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class VentaServices
    {
        private readonly Contexto _contexto;
        public VentaServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int ventaId)
        {
            return await _contexto.ventas.AnyAsync(c => c.VentaId == ventaId);
        }
        public async Task<bool> Insertar(Venta venta)
        {
            _contexto.ventas.Add(venta);
            return await _contexto.SaveChangesAsync() > 0;
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
            var c = await _contexto.ventas.FindAsync(venta.VentaId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(venta).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Venta?> Buscar(int ventaId)
        {
            return await _contexto.ventas
                .Where(c => c.VentaId == ventaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
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

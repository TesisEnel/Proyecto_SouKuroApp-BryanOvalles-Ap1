using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class ProveedorServices
    {
        private readonly ApplicationDbContext _contexto;
        public ProveedorServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int proveedorId)
        {
            return await _contexto.proveedores.AnyAsync(c => c.ProveedorId == proveedorId);
        }
        public async Task<bool> Insertar(Proveedor proveedor)
        {
            _contexto.proveedores.Add(proveedor);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Proveedor proveedor)
        {
            var c = await _contexto.proveedores.FindAsync(proveedor.ProveedorId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(proveedor).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Proveedor proveedor)
        {
            if (!await Existe(proveedor.ProveedorId))
                return await Insertar(proveedor);
            else
                return await Modificar(proveedor);
        }
        public async Task<bool> Eliminar(Proveedor proveedor)
        {
            var c = await _contexto.proveedores.FindAsync(proveedor.ProveedorId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(proveedor).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Proveedor?> Buscar(int proveedorId)
        {
            return await _contexto.proveedores
                .Where(c => c.ProveedorId == proveedorId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Proveedor>> Listar(Expression<Func<Proveedor, bool>> Criterio)
        {
            return await _contexto.proveedores
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

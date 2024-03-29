using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class CompraServices
    {
        private readonly Contexto _contexto;
        public CompraServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int CompraId)
        {
            return await _contexto.compras.AnyAsync(c => c.CompraId == CompraId);
        }
        public async Task<bool> Insertar(Compra compras)
        {
            _contexto.compras.Add(compras);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Compra compra)
        {
            var c = await _contexto.compras.FindAsync(compra.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(compra).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Compra compra)
        {
            if (!await Existe(compra.CompraId))
                return await Insertar(compra);
            else
                return await Modificar(compra);
        }
        public async Task<bool> Eliminar(Compra compra)
        {
            var c = await _contexto.compras.FindAsync(compra.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(compra).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Compra?> Buscar(int CompraId)
        {
            return await _contexto.compras
                .Where(c => c.CompraId == CompraId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Compra>> Listar(Expression<Func<Compra, bool>> Criterio)
        {
            return await _contexto.compras
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

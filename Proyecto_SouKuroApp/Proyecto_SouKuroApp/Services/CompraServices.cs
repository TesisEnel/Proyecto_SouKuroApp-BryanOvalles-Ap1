using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto_SouKuroApp.Services
{
    public class CompraServices
    {
        private readonly ApplicationDbContext _contexto;
        public CompraServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int CompraId)
        {
            return await _contexto.compras.AnyAsync(c => c.CompraId == CompraId);
        }
        public async Task<Compra?> GetCompras(int id)
        {
            return await _contexto.compras.Include(c => c.Detalle).FirstOrDefaultAsync(c => c.CompraId == id);
        }
        public async Task<bool> Insertar(Compra Compras)
        {
            _contexto.compras.Add(Compras);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Compra Compras)
        {
            var c = await _contexto.compras.FindAsync(Compras.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(Compras).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Compra Compras)
        {
            if (!await Existe(Compras.CompraId))
                return await Insertar(Compras);
            else
                return await Modificar(Compras);
        }
        public async Task<bool> Eliminar(Compra Compras)
        {
            var c = await _contexto.compras.FindAsync(Compras.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(Compras).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Compra?> Buscar(int CompraId)
        {
            return await _contexto.compras
                .Where(c => c.CompraId == CompraId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
            //.Include(c => c.ComprasDetalle)
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
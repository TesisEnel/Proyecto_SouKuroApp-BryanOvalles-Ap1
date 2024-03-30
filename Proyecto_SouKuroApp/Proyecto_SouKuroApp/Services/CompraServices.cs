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

        public async Task<bool> Insertar(Compra compras)
        {
            _contexto.compras.Add(compras);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Compra?> GetCompras(int id)
        {
            return await _contexto.compras.Include(c => c.Detalle).FirstOrDefaultAsync(c => c.CompraId == id);
        }

        public async Task<bool> Modificar(Compra compra)
        {
            _contexto.Update(compra);
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
            _contexto.compras.Remove(compra);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Compra?> Buscar(int CompraId)
        {
            return await _contexto.compras
                .Where(c => c.CompraId == CompraId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<Compra?> BuscarNFC(string nfc)
        {
            return await _contexto.compras
                .AsNoTracking() // Agregar esta línea
                .FirstOrDefaultAsync(s => s.NFC == nfc);
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
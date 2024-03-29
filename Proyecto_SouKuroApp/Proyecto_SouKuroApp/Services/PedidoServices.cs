using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class PedidoServices
    {
        private readonly ApplicationDbContext _contexto;
        public PedidoServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int pedidoId)
        {
            return await _contexto.pedidos.AnyAsync(c => c.PedidoId == pedidoId);
        }
        public async Task<bool> Insertar(Pedido pedido)
        {
            _contexto.pedidos.Add(pedido);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Pedido pedido)
        {
            var c = await _contexto.pedidos.FindAsync(pedido.PedidoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(pedido).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Pedido pedido)
        {
            if (!await Existe(pedido.PedidoId))
                return await Insertar(pedido);
            else
                return await Modificar(pedido);
        }
        public async Task<bool> Eliminar(Pedido pedido)
        {
            var c = await _contexto.pedidos.FindAsync(pedido.PedidoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(pedido).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Pedido?> Buscar(int pedidoId)
        {
            return await _contexto.pedidos
                .Where(c => c.PedidoId == pedidoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Pedido>> Listar(Expression<Func<Pedido, bool>> Criterio)
        {
            return await _contexto.pedidos
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

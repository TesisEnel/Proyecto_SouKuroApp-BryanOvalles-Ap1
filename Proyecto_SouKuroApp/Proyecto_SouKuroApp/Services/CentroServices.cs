using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services;

public class CentroServices

{

    private readonly ApplicationDbContext _contexto;
  
    public CentroServices(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int pedidoClienteIdPedidoId)
    {
        return await _contexto.centro_de_Pedidos.AnyAsync(c => c.PedidoClienteId == pedidoClienteIdPedidoId);
    }
    public async Task<Centro_de_Pedidos?> GetCentroPed(int id)
    {
        return await _contexto.centro_de_Pedidos.Include(c => c.Detalle).FirstOrDefaultAsync(c => c.PedidoClienteId == id);
    }
    public async Task<bool> Insertar(Centro_de_Pedidos pedido)
    {
        _contexto.centro_de_Pedidos.Add(pedido);
        int filasAfectadas = await _contexto.SaveChangesAsync();
        return filasAfectadas > 0;
    }
    public async Task<bool> Modificar(Centro_de_Pedidos pedido)
    {
        var c = await _contexto.centro_de_Pedidos.FindAsync(pedido.PedidoClienteId);
        _contexto.Entry(c!).State = EntityState.Detached;
        _contexto.Entry(pedido).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Centro_de_Pedidos pedido)
    {
        if (!await Existe(pedido.PedidoClienteId))
            return await Insertar(pedido);
        else
            return await Modificar(pedido);
    }
    public async Task<bool> Eliminar(Centro_de_Pedidos pedido)
    {
        var c = await _contexto.centro_de_Pedidos.FindAsync(pedido.PedidoClienteId);
        _contexto.Entry(c!).State = EntityState.Detached;
        _contexto.Entry(pedido).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Centro_de_Pedidos?> Buscar(int pedidoClienteId)
    {
        return await _contexto.centro_de_Pedidos
            .Where(c => c.PedidoClienteId == pedidoClienteId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        //.Include(c => c.ComprasDetalle)
    }
    public async Task<List<Centro_de_Pedidos>> Listar(Expression<Func<Centro_de_Pedidos, bool>> Criterio)
    {
        return await _contexto.centro_de_Pedidos
                .Where(Criterio)
                .AsNoTracking()
                .ToListAsync();
    }

  
}

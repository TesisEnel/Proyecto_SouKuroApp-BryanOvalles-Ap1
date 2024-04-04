using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class ReservacionServices
    {

       

            private readonly ApplicationDbContext _contexto;
            public ReservacionServices(ApplicationDbContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<bool> Existe(int ReservacionId)
            {
                return await _contexto.reservacion.AnyAsync(c => c.ReservacionId == ReservacionId);
            }
         
            public async Task<bool> Insertar(Reservacion reservacion)
            {
                _contexto.reservacion.Add(reservacion);
                int filasAfectadas = await _contexto.SaveChangesAsync();
                return filasAfectadas > 0;
            }
            public async Task<bool> Modificar(Reservacion reservacion)
            {
                var c = await _contexto.reservacion.FindAsync(reservacion.ReservacionId);
                _contexto.Entry(c!).State = EntityState.Detached;
                _contexto.Entry(reservacion).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0;
            }
            public async Task<bool> Guardar(Reservacion reservacion)
            {
                if (!await Existe(reservacion.ReservacionId))
                    return await Insertar(reservacion);
                else
                    return await Modificar(reservacion);
            }
            public async Task<bool> Eliminar(Reservacion reservacion)
            {
                var c = await _contexto.reservacion.FindAsync(reservacion.ReservacionId);
                _contexto.Entry(c!).State = EntityState.Detached;
                _contexto.Entry(reservacion).State = EntityState.Deleted;
                return await _contexto.SaveChangesAsync() > 0;
            }
            public async Task<Reservacion?> Buscar(int reservacion)
            {
                return await _contexto.reservacion
                    .Where(c => c.ReservacionId == reservacion)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
                
            }
            public async Task<List<Reservacion>> Listar(Expression<Func<Reservacion, bool>> Criterio)
            {
                return await _contexto.reservacion
                        .Where(Criterio)
                        .AsNoTracking()
                        .ToListAsync();
            }
        }
    }

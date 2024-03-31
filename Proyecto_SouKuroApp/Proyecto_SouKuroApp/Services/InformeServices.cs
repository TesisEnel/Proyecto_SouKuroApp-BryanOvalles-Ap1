using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class InformeServices
    {

        private readonly ApplicationDbContext _contexto;
        public InformeServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int InformeId)
        {
            return await _contexto.Informes.AnyAsync(c => c.InformeId == InformeId);
        }
        /* public async Task<Usuario?> GetCompras(int id)
         {
             return await _contexto.usuarios.Include(c => c.Detalle).FirstOrDefaultAsync(c => c.CompraId == id);
         }*/
        public async Task<bool> Insertar(Informe informe)
        {
            _contexto.Informes.Add(informe);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Informe informe)
        {
            var c = await _contexto.Informes.FindAsync(informe.InformeId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(informe).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Informe informe)
        {
            if (!await Existe(informe.InformeId))
                return await Insertar(informe);
            else
                return await Modificar(informe);
        }
        public async Task<bool> Eliminar(Informe informe)
        {
            var c = await _contexto.Informes.FindAsync(informe.InformeId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(informe).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Informe?> Buscar(int informe)
        {
            return await _contexto.Informes
                .Where(c => c.InformeId == informe)
                .AsNoTracking()
                .SingleOrDefaultAsync();
            //.Include(c => c.ComprasDetalle)
        }
        public async Task<List<Informe>> Listar(Expression<Func<Informe, bool>> Criterio)
        {
            return await _contexto.Informes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

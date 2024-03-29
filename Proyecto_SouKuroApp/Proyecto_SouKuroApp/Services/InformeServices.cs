using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class InformeServices
    {
        private readonly Contexto _contexto;
        public InformeServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int informeId)
        {
            return await _contexto.Informes.AnyAsync(c => c.InformeId == informeId);
        }
        public async Task<bool> Insertar(Informe informe)
        {
            _contexto.Informes.Add(informe);
            return await _contexto.SaveChangesAsync() > 0;
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
        public async Task<Informe?> Buscar(int InformeId)
        {
            return await _contexto.Informes
                .Where(c => c.InformeId == InformeId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
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

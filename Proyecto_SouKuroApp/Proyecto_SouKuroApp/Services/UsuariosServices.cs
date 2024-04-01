using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.Data;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class UsuariosServices
    {

        private readonly ApplicationDbContext _contexto;
        public UsuariosServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int UsuarioId)
        {
            return await _contexto.usuarios.AnyAsync(c => c.UsuarioId == UsuarioId);
        }
        public async Task<ApplicationUser?> GetUser(string id)
        {
            return _contexto.Users.FirstOrDefault(t => t.Id == id);
        }

        public async Task<bool> Insertar(Usuario usuario)
        {
            _contexto.usuarios.Add(usuario);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Usuario usuario)
        {
            var c = await _contexto.usuarios.FindAsync(usuario.UsuarioId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(usuario).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Usuario usuario)
        {
            if (!await Existe(usuario.UsuarioId))
                return await Insertar(usuario);
            else
                return await Modificar(usuario);
        }
        public async Task<bool> Delete(string id)
        {
            return await _contexto!.Users
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<Usuario?> Buscar(int usuario)
        {
            return await _contexto.usuarios
                .Where(c => c.UsuarioId == usuario)
                .AsNoTracking()
                .SingleOrDefaultAsync();
            //.Include(c => c.ComprasDetalle)
        }
        public async Task<List<Usuario>> Listar(Expression<Func<Usuario, bool>> Criterio)
        {
            return await _contexto.usuarios
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Proyecto_SouKuroApp.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace Proyecto_SouKuroApp.Services
{
    public class UsuariosServices
    {
      
            private readonly Contexto _contexto;
            public UsuariosServices(Contexto contexto)
            {
                _contexto = contexto;
            }
            public async Task<bool> Existe(int usuarioId)
            {
                return await _contexto.usuarios.AnyAsync(c => c.UsuarioId == usuarioId);
            }
            public async Task<bool> Insertar(Usuario usuario)
            {
                _contexto.usuarios.Add(usuario);
                return await _contexto.SaveChangesAsync() > 0;
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
            public async Task<bool> Eliminar(Usuario usuario)
            {
                var c = await _contexto.usuarios.FindAsync(usuario.UsuarioId);
                _contexto.Entry(c!).State = EntityState.Detached;
                _contexto.Entry(usuario).State = EntityState.Deleted;
                return await _contexto.SaveChangesAsync() > 0;
            }
            public async Task<Usuario?> Buscar(int usuarioId)
            {
                return await _contexto.usuarios
                    .Where(c => c.UsuarioId == usuarioId)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
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

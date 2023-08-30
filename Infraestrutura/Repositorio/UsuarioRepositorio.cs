using Dominio;
using Infraestrutura.DBContext;
using Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _pcfContexto;
        public UsuarioRepositorio(AppDbContext pcfContexto)
        {
            _pcfContexto = pcfContexto;
        }

        public async Task<Usuario> ObterUsuario(string login, string senha)
        {
            return await _pcfContexto.Usuarios
                                .AsNoTracking()
                                .FirstOrDefaultAsync(n => n.Login == login && n.Senha == senha);
        }

        public async Task<Usuario> ObterUsuarioPorLogin(string login)
        {
            return await _pcfContexto.Usuarios
                                .AsNoTracking()
                                .FirstOrDefaultAsync(n => n.Login == login);
        }
    }
}

using Dominio;

namespace Infraestrutura.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObterUsuario(string login, string senha);
        Task<Usuario> ObterUsuarioPorLogin(string login);
    }
}

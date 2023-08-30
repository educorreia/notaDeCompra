using Aplicacao.Model;
using Dominio;

namespace Aplicacao.Interface
{
    public interface IUsuarioServico
    {
        Task<string> Autenticar(LoginModel model);
        Task<Usuario> ObterUsuarioPorLogin(string login);
    }
}

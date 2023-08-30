using Aplicacao.Interface;
using Aplicacao.Model;
using Dominio;
using Infraestrutura.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplicacao.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<string> Autenticar(LoginModel model)
        {
            var resposta = await _usuarioRepositorio.ObterUsuario(model.Login, model.Senha);

            if(resposta != null)
            {
                return GerarToken(model.Login);
            }
            else
                return "Usuario não encontrado";
        }

        public async Task<Usuario> ObterUsuarioPorLogin(string login)
        {
            return await _usuarioRepositorio.ObterUsuarioPorLogin(login);
        }

        public string GerarToken(string login)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            byte[] bytes = Encoding.ASCII.GetBytes("7C87A8A9-34B7-4CB1-A480-4E6A8FBE849B");

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, login)
                }),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(600)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

    }
}

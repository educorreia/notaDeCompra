using Aplicacao.Interface;
using Aplicacao.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<string> Get([FromBody] LoginModel model)
        {
            return await _usuarioServico.Autenticar(model);
        }
    }
}
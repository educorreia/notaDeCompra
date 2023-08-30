using Aplicacao.Interface;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    public class AprovacaoController : ControllerBase
    {
        private readonly INotaServico _notaServico;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AprovacaoController(INotaServico notaServico, IHttpContextAccessor httpContextAccessor)
        {
            _notaServico = notaServico;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet("notas")]
        public async Task<IEnumerable<Nota>> Get()
        {
            var loginUsuario = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _notaServico.GetNotasDisponiveis(loginUsuario);
        }

        [Authorize]
        [HttpPost("aprovar-nota/{notaId}")]
        public async Task<bool> AprovarNota(int notaId)
        {
            var loginUsuario = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _notaServico.AprovarNotaMercadoria(notaId, loginUsuario);
        }
    }
}

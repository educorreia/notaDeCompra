using Aplicacao.Interface;
using Dominio;
using Dominio.Enum;
using Infraestrutura.Interfaces;

namespace Aplicacao.Servico
{
    public class NotaServico : INotaServico
    {
        private readonly INotaRepositorio _notaRepositorio;
        private readonly IUsuarioServico _usuarioServico;

        public NotaServico(INotaRepositorio notaRepositorio, IUsuarioServico usuarioServico)
        {
            _notaRepositorio = notaRepositorio;
            _usuarioServico = usuarioServico;
        }

        public async Task<IEnumerable<Nota>> GetNotasDisponiveis(string usuarioLogin)
        {
            var usuarioLogado = await _usuarioServico.ObterUsuarioPorLogin(usuarioLogin);
            if (usuarioLogado == null)
                return null;

            return await _notaRepositorio.GetNotaParaAprovar(usuarioLogado);
        }

        public async Task<bool> AprovarNotaMercadoria(int notaId, string usuarioLogin)
        {
            var usuarioLogado = await _usuarioServico.ObterUsuarioPorLogin(usuarioLogin);
            if (usuarioLogado == null)
                return false;

            var nota = await _notaRepositorio.GetNotaParaAprovar(usuarioLogado, notaId);
            if (nota == null || !nota.Any())
                return false;

            await _notaRepositorio.AprovarNotaDeCompra(usuarioLogado.UsuarioId, notaId, usuarioLogado.Papel);

            if (await _notaRepositorio.NotaMercadoriaAprovada(notaId))
                await _notaRepositorio.AtualizarStatusNotaCompra(notaId, Status.Aprovado);

            return true;
        }
    }
}

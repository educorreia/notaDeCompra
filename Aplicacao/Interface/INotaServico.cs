using Dominio;

namespace Aplicacao.Interface
{
    public interface INotaServico
    {
        Task<IEnumerable<Nota>> GetNotasDisponiveis(string usuarioLogin);
        Task<bool> AprovarNotaMercadoria(int notaId, string usuarioLogin);
    }
}

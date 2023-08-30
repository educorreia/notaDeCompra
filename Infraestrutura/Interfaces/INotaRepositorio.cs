using Dominio;
using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface INotaRepositorio
    {
        Task<List<Nota>> GetNotaParaAprovar(Usuario usuario, int? notaId = null);
        Task AprovarNotaDeCompra(int usuarioId, int notaId, Papel operacao);
        Task<bool> NotaMercadoriaAprovada(int notaId);
        Task AtualizarStatusNotaCompra(int notaId, Status status);
    }
}

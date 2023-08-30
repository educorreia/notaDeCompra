using Dominio;
using Dominio.Enum;
using Infraestrutura.DBContext;
using Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class NotaRepositorio : INotaRepositorio
    {
        private readonly AppDbContext _pcfContexto;

        public NotaRepositorio(AppDbContext pcfContexto)
        {
            _pcfContexto = pcfContexto;
        }

        public async Task<List<Nota>> GetNotaParaAprovar(Usuario usuario, int? notaId = null)
        {
            var query =  (from n in _pcfContexto.Notas
                        from c in _pcfContexto.Configuracoes.Where(c => n.ValorTotal >= c.FaixaInicial && n.ValorTotal <= c.FaixaFinal)
                        where n.Status == Status.Pendente && n.ValorTotal >= usuario.ValorMinimo && n.ValorTotal <= usuario.ValorMaximo
                              && !n.Aprovacoes.Select(t => t.UsuarioId).Contains(usuario.UsuarioId)  
                             && n.Aprovacoes.Where(t => (int)t.Operacao == (int)usuario.Papel).Count() <  (usuario.Papel == Papel.Visto ? c.QuantidadeVistos : c.QuantidadeAprovacoes)
                        select n);

            if (notaId.HasValue)
                query = query.Where(n => n.NotaId.Equals(notaId.Value));

            return await query.ToListAsync();
        }


        public async Task AprovarNotaDeCompra(int usuarioId, int notaId, Papel operacao)
        {
            _pcfContexto.Add(new HistoricoAprovacao
            {
                NotaId = notaId,
                UsuarioId = usuarioId,
                Operacao = operacao,
                Data = DateTime.Now
            });
            await _pcfContexto.SaveChangesAsync();
        }

        public async Task<bool> NotaMercadoriaAprovada(int notaId)
        {
            return await (from n in _pcfContexto.Notas
                         from c in _pcfContexto.Configuracoes.Where(c => n.ValorTotal >= c.FaixaInicial && n.ValorTotal <= c.FaixaFinal)
                         where n.NotaId == notaId 
                                && n.Aprovacoes.Where(t => (int)t.Operacao == (int)Papel.Visto).Count() ==  c.QuantidadeVistos
                                &&  n.Aprovacoes.Where(t => (int)t.Operacao == (int)Papel.Aprovacao).Count() == c.QuantidadeAprovacoes
                         select n).AnyAsync();
        }

        public async Task AtualizarStatusNotaCompra(int notaId, Status status)
        {
            var nota = await _pcfContexto.Notas.FirstOrDefaultAsync(n => n.NotaId.Equals(notaId));
            if (nota == null)
                return;

            nota.Status = status;
            await _pcfContexto.SaveChangesAsync();
        }
    }
}

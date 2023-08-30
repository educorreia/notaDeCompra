using Dominio.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Nota
    {
        public int NotaId { get; set; }
        public DateTime DataEmissao { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorMercadorias { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorDesconto { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorFrete { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }
        public Status Status { get; set; }
        public ICollection<HistoricoAprovacao> Aprovacoes { get; set; }
    }
}

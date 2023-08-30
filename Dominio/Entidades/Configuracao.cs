using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Configuracao
    {
        public int Id { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal FaixaInicial { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal  FaixaFinal { get; set;}
        public int QuantidadeVistos { get; set; }
        public int QuantidadeAprovacoes { get; set; }
    }
}

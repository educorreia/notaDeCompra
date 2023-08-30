using Dominio.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Papel Papel { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorMinimo { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorMaximo { get; set; }
    }
}

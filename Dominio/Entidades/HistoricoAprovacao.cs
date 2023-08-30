using Dominio.Enum; 

namespace Dominio
{
    public class HistoricoAprovacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Papel Operacao { get; set; }
        public int UsuarioId { get; set; }
        public int NotaId { get; set; }
        public Usuario Usuario { get; set; }
        public Nota Nota { get; set; }
    }
}

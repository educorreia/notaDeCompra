using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class DadosNota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Notas(DataEmissao, ValorMercadorias, ValorDesconto, ValorFrete, ValorTotal, Status) Values ('2023-08-28', 5000, 500, 100, 4600, 0)");
            migrationBuilder.Sql("INSERT INTO Notas(DataEmissao, ValorMercadorias, ValorDesconto, ValorFrete, ValorTotal, Status) Values ('2023-08-28', 50000, 5000, 1000, 46000, 0)");
            migrationBuilder.Sql("INSERT INTO Notas(DataEmissao, ValorMercadorias, ValorDesconto, ValorFrete, ValorTotal, Status) Values ('2023-08-28', 4000, 500, 100, 4600, 0)");
            migrationBuilder.Sql("INSERT INTO Notas(DataEmissao, ValorMercadorias, ValorDesconto, ValorFrete, ValorTotal, Status) Values ('2023-08-28', 5000, 500, 100, 4600, 0)");
            migrationBuilder.Sql("INSERT INTO Notas(DataEmissao, ValorMercadorias, ValorDesconto, ValorFrete, ValorTotal, Status) Values ('2023-08-28', 5000, 500, 100, 4600, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Notas");
        }
    }
}

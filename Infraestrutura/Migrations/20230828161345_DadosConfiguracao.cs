using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class DadosConfiguracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Configuracoes(FaixaInicial, FaixaFinal, QuantidadeVistos, QuantidadeAprovacoes) Values (0, 1000, 1, 0)");
            migrationBuilder.Sql("INSERT INTO Configuracoes(FaixaInicial, FaixaFinal, QuantidadeVistos, QuantidadeAprovacoes) Values (1000.01, 10000, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Configuracoes(FaixaInicial, FaixaFinal, QuantidadeVistos, QuantidadeAprovacoes) Values (10000.01, 50000, 2, 1)");
            migrationBuilder.Sql("INSERT INTO Configuracoes(FaixaInicial, FaixaFinal, QuantidadeVistos, QuantidadeAprovacoes) Values (50000.01, 999999.99, 2, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Configuracaoes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class DadosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Usuarios(Login, Senha, Papel, ValorMinimo, ValorMaximo) Values ('usuario01', '123456', 0, 5000, 15000)");
            migrationBuilder.Sql("INSERT INTO Usuarios(Login, Senha, Papel, ValorMinimo, ValorMaximo) Values ('usuario02', '254689', 0, 15000, 50000)");
            migrationBuilder.Sql("INSERT INTO Usuarios(Login, Senha, Papel, ValorMinimo, ValorMaximo) Values ('usuario03', '545421', 1, 5000, 15000)");
            migrationBuilder.Sql("INSERT INTO Usuarios(Login, Senha, Papel, ValorMinimo, ValorMaximo) Values ('usuario04', '645458', 1, 15000, 50000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Usuarios");
        }
    }
}

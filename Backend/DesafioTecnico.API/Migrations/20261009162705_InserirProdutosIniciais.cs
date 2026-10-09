using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesafioTecnico.API.Migrations
{
    /// <inheritdoc />
    public partial class InserirProdutosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "CodigoProduto", "DescricaoProduto", "Estoque" },
                values: new object[,]
                {
                    { 101, "Caneta Azul", 150 },
                    { 102, "Caderno Universitário", 75 },
                    { 103, "Borracha Branca", 200 },
                    { 104, "Lápis Preto HB", 320 },
                    { 105, "Marcador de Texto Amarelo", 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "CodigoProduto",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "CodigoProduto",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "CodigoProduto",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "CodigoProduto",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "CodigoProduto",
                keyValue: 105);
        }
    }
}

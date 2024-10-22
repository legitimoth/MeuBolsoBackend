using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBolsoBackend
{
    /// <inheritdoc />
    public partial class SeedTipoPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserindo os registros na tabela TipoPagamento
            migrationBuilder.InsertData(
                table: "TiposPagamento",
                columns: ["Id", "Nome"],
                values: new object[,]
                {
                    { 1, "Pix" },
                    { 2, "Cartao" },
                    { 3, "Dinheiro" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                            table: "TiposPagamento",
                            keyColumn: "Id",
                            keyValues: [1, 2, 3]);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBolsoBackend
{
    /// <inheritdoc />
    public partial class AddPagamentoDataHora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataHora",
                table: "Pagamentos",
                type: "timestamp with time zone",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Pagamentos");
        }
    }
}

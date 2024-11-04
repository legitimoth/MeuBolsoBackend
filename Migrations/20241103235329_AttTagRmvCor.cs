using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBolsoBackend
{
    /// <inheritdoc />
    public partial class AttTagRmvCor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Tags",
                type: "character varying(7)",
                maxLength: 7,
                nullable: true);
        }
    }
}

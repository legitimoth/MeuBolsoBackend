using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeuBolsoBackend;
/// <inheritdoc />
public partial class AddTag : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Cor = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                UsuarioId = table.Column<long>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tags_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tags_UsuarioId",
            table: "Tags",
            column: "UsuarioId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tags");
    }
}

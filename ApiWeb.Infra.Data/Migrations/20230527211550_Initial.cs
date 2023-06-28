using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sistema");

            migrationBuilder.CreateTable(
                name: "registro_financeiro",
                schema: "sistema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    valor_total = table.Column<decimal>(type: "numeric", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registro_financeiro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operacao",
                schema: "sistema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    registro_financeiro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_financeiro = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operacao", x => x.id);
                    table.ForeignKey(
                        name: "fk_operacao_registro_financeiro_registro_financeiro_id",
                        column: x => x.registro_financeiro_id,
                        principalSchema: "sistema",
                        principalTable: "registro_financeiro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_operacao_registro_financeiro_id",
                schema: "sistema",
                table: "operacao",
                column: "registro_financeiro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operacao",
                schema: "sistema");

            migrationBuilder.DropTable(
                name: "registro_financeiro",
                schema: "sistema");
        }
    }
}

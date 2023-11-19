using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "produto",
                schema: "sistema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registros_financeiros",
                schema: "sistema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric", nullable: false),
                    codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registros_financeiros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transacoes",
                schema: "sistema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    valor_transacao = table.Column<decimal>(type: "numeric", nullable: false),
                    registro_financeiro_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_transacao_enum = table.Column<int>(type: "integer", nullable: false),
                    codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transacoes", x => x.id);
                    table.ForeignKey(
                        name: "fk_transacoes_registros_financeiros_registro_financeiro_id",
                        column: x => x.registro_financeiro_id,
                        principalSchema: "sistema",
                        principalTable: "registros_financeiros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_transacoes_registro_financeiro_id",
                schema: "sistema",
                table: "transacoes",
                column: "registro_financeiro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto",
                schema: "sistema");

            migrationBuilder.DropTable(
                name: "transacoes",
                schema: "sistema");

            migrationBuilder.DropTable(
                name: "registros_financeiros",
                schema: "sistema");
        }
    }
}

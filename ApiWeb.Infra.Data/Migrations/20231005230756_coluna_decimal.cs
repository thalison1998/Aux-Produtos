using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class coluna_decimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valor_transacao",
                schema: "sistema",
                table: "transacoes",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_total",
                schema: "sistema",
                table: "registros_financeiros",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valor_transacao",
                schema: "sistema",
                table: "transacoes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_total",
                schema: "sistema",
                table: "registros_financeiros",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }
    }
}

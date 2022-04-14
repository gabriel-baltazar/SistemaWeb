using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWeb.Migrations.ContextoMigrations
{
    public partial class TerceiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Contas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "Contas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Valor",
                table: "Contas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Contas");
        }
    }
}

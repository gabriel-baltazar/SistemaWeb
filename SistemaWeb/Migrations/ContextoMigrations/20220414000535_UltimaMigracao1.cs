using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWeb.Migrations.ContextoMigrations
{
    public partial class UltimaMigracao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Tipo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Classificacao",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Tipo");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Classificacao");
        }
    }
}

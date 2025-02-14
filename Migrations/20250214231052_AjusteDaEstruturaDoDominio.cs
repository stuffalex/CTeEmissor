using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTeEmissor.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDaEstruturaDoDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PesoUnitario",
                table: "Carga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoUnitario",
                table: "Carga");
        }
    }
}

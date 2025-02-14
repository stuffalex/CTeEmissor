using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTeEmissor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliquota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Porcentagem = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliquota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    PesoBrutoTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    Volume = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CepOrigem = table.Column<string>(type: "TEXT", nullable: false),
                    CepDestino = table.Column<string>(type: "TEXT", nullable: false),
                    DistanciaOrigemDestino = table.Column<int>(type: "INTEGER", nullable: false),
                    InicioOperacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AliquotaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DespesasAdicionais = table.Column<decimal>(type: "TEXT", nullable: false),
                    TarifaPorPeso = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viagem_Aliquota_AliquotaId",
                        column: x => x.AliquotaId,
                        principalTable: "Aliquota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeComprador = table.Column<string>(type: "TEXT", nullable: false),
                    CargaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ViagemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ValorDoFrete = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorDoIcms = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Carga_CargaId",
                        column: x => x.CargaId,
                        principalTable: "Carga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Viagem_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorIcms = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cte_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CargaId",
                table: "Compra",
                column: "CargaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ViagemId",
                table: "Compra",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cte_CompraId",
                table: "Cte",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_AliquotaId",
                table: "Viagem",
                column: "AliquotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cte");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Carga");

            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Aliquota");
        }
    }
}

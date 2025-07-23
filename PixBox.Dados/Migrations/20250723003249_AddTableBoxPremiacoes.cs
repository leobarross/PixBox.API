using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixBox.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBoxPremiacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxPremiacoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(37)", maxLength: 37, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxPremiacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxPremiacoes");
        }
    }
}

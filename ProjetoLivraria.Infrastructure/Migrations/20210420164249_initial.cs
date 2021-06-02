using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoLivraria.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "varchar(100)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(200)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    ImagemCapa = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livros");
        }
    }
}

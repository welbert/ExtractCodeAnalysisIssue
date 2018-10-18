using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeAnalysisReport.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeAnalysis",
                columns: table => new
                {
                    CodeAnalysisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Projeto = table.Column<string>(maxLength: 100, nullable: false),
                    Solution = table.Column<string>(maxLength: 100, nullable: false),
                    Severidade = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Dll = table.Column<string>(maxLength: 70, nullable: true),
                    CaminhoArquivo = table.Column<string>(maxLength: 255, nullable: true),
                    LinhaCodigo = table.Column<int>(nullable: false),
                    DataExecucao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeAnalysis", x => x.CodeAnalysisId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeAnalysis");
        }
    }
}

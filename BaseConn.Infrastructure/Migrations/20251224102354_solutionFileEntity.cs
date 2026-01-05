using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseConn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class solutionFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "solutionFiles",
                columns: table => new
                {
                    SolutionFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionFileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SolutionFileSize = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solutionFiles", x => x.SolutionFileId);
                    table.ForeignKey(
                        name: "FK_solutionFiles_solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "solutions",
                        principalColumn: "solution_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_solutionFiles_SolutionId",
                table: "solutionFiles",
                column: "SolutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "solutionFiles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionReferences.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_References_Projects_ReferencedProjectProjectId",
                table: "References");

            migrationBuilder.RenameColumn(
                name: "ReferencedProjectProjectId",
                table: "References",
                newName: "ReferencedByProjectProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_References_ReferencedProjectProjectId",
                table: "References",
                newName: "IX_References_ReferencedByProjectProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_References_Projects_ReferencedByProjectProjectId",
                table: "References",
                column: "ReferencedByProjectProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_References_Projects_ReferencedByProjectProjectId",
                table: "References");

            migrationBuilder.RenameColumn(
                name: "ReferencedByProjectProjectId",
                table: "References",
                newName: "ReferencedProjectProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_References_ReferencedByProjectProjectId",
                table: "References",
                newName: "IX_References_ReferencedProjectProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_References_Projects_ReferencedProjectProjectId",
                table: "References",
                column: "ReferencedProjectProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}

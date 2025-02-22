using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionReferences.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AssemblyVersion = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectType = table.Column<string>(type: "TEXT", nullable: true),
                    AssemblyName = table.Column<string>(type: "TEXT", nullable: true),
                    RootNamespace = table.Column<string>(type: "TEXT", nullable: true),
                    TargetFramework = table.Column<string>(type: "TEXT", nullable: true),
                    PackageId = table.Column<string>(type: "TEXT", nullable: true),
                    PackageVersion = table.Column<string>(type: "TEXT", nullable: true),
                    AssemblyFileVersion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    SolutionId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    SolutionType = table.Column<string>(type: "TEXT", nullable: true),
                    SolutionTypeVersion = table.Column<string>(type: "TEXT", nullable: true),
                    VisualStudioSolutionFileVersion = table.Column<string>(type: "TEXT", nullable: true),
                    VisualStudioFormatVersion = table.Column<string>(type: "TEXT", nullable: true),
                    MinimumVisualStudioVersion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.SolutionId);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ReferenceId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    ReferenceType = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    ReferencedProjectProjectId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_References_Projects_ReferencedProjectProjectId",
                        column: x => x.ReferencedProjectProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSolution",
                columns: table => new
                {
                    ProjectsProjectId = table.Column<string>(type: "TEXT", nullable: false),
                    SolutionsSolutionId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSolution", x => new { x.ProjectsProjectId, x.SolutionsSolutionId });
                    table.ForeignKey(
                        name: "FK_ProjectSolution_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSolution_Solutions_SolutionsSolutionId",
                        column: x => x.SolutionsSolutionId,
                        principalTable: "Solutions",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectReference",
                columns: table => new
                {
                    ProjectsProjectId = table.Column<string>(type: "TEXT", nullable: false),
                    ReferencesReferenceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReference", x => new { x.ProjectsProjectId, x.ReferencesReferenceId });
                    table.ForeignKey(
                        name: "FK_ProjectReference_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectReference_References_ReferencesReferenceId",
                        column: x => x.ReferencesReferenceId,
                        principalTable: "References",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReference_ReferencesReferenceId",
                table: "ProjectReference",
                column: "ReferencesReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSolution_SolutionsSolutionId",
                table: "ProjectSolution",
                column: "SolutionsSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ReferencedProjectProjectId",
                table: "References",
                column: "ReferencedProjectProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectReference");

            migrationBuilder.DropTable(
                name: "ProjectSolution");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

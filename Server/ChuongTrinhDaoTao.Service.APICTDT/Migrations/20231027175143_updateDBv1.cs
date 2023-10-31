using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class updateDBv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education_BOK");

            migrationBuilder.DropTable(
                name: "EducationProgram");

            migrationBuilder.DropColumn(
                name: "EducationProgramId",
                table: "Cohort_Major");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationProgramId",
                table: "Cohort_Major",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EducationProgram",
                columns: table => new
                {
                    EducationProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CohortId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationProgram", x => x.EducationProgramId);
                    table.ForeignKey(
                        name: "FK_EducationProgram_Cohort_Major_CohortId_MajorId",
                        columns: x => new { x.CohortId, x.MajorId },
                        principalTable: "Cohort_Major",
                        principalColumns: new[] { "CohortId", "MajorId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education_BOK",
                columns: table => new
                {
                    BlockOfKnowledgeId = table.Column<int>(type: "int", nullable: false),
                    EducationProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_BOK", x => new { x.BlockOfKnowledgeId, x.EducationProgramId });
                    table.ForeignKey(
                        name: "FK_Education_BOK_BlockOfKnowledge_BlockOfKnowledgeId",
                        column: x => x.BlockOfKnowledgeId,
                        principalTable: "BlockOfKnowledge",
                        principalColumn: "BlockOfKnowledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_BOK_EducationProgram_EducationProgramId",
                        column: x => x.EducationProgramId,
                        principalTable: "EducationProgram",
                        principalColumn: "EducationProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_BOK_EducationProgramId",
                table: "Education_BOK",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationProgram_CohortId_MajorId",
                table: "EducationProgram",
                columns: new[] { "CohortId", "MajorId" },
                unique: true);
        }
    }
}

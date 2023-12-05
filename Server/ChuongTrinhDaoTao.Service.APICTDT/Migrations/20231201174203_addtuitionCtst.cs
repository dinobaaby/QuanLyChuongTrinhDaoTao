using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class addtuitionCtst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TuitionCTDT",
                columns: table => new
                {
                    TuitionId = table.Column<int>(type: "int", nullable: false),
                    CohortId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionCTDT", x => new { x.TuitionId, x.MajorId, x.CohortId });
                    table.ForeignKey(
                        name: "FK_TuitionCTDT_Cohort_Major_CohortId_MajorId",
                        columns: x => new { x.CohortId, x.MajorId },
                        principalTable: "Cohort_Major",
                        principalColumns: new[] { "CohortId", "MajorId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuitionCTDT_Tuition_TuitionId",
                        column: x => x.TuitionId,
                        principalTable: "Tuition",
                        principalColumn: "TuitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TuitionCTDT_CohortId_MajorId",
                table: "TuitionCTDT",
                columns: new[] { "CohortId", "MajorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TuitionCTDT");
        }
    }
}

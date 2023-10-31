using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class addCourseBOK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationProgram_Cohort_Major_CohortId_MajorId",
                table: "EducationProgram");

            migrationBuilder.DropIndex(
                name: "IX_EducationProgram_CohortId_MajorId",
                table: "EducationProgram");

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "EducationProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CohortId",
                table: "EducationProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CohortId",
                table: "BlockOfKnowledge_Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "BlockOfKnowledge_Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EducationProgram_CohortId_MajorId",
                table: "EducationProgram",
                columns: new[] { "CohortId", "MajorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockOfKnowledge_Course_CohortId_MajorId",
                table: "BlockOfKnowledge_Course",
                columns: new[] { "CohortId", "MajorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlockOfKnowledge_Course_Cohort_Major_CohortId_MajorId",
                table: "BlockOfKnowledge_Course",
                columns: new[] { "CohortId", "MajorId" },
                principalTable: "Cohort_Major",
                principalColumns: new[] { "CohortId", "MajorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationProgram_Cohort_Major_CohortId_MajorId",
                table: "EducationProgram",
                columns: new[] { "CohortId", "MajorId" },
                principalTable: "Cohort_Major",
                principalColumns: new[] { "CohortId", "MajorId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockOfKnowledge_Course_Cohort_Major_CohortId_MajorId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationProgram_Cohort_Major_CohortId_MajorId",
                table: "EducationProgram");

            migrationBuilder.DropIndex(
                name: "IX_EducationProgram_CohortId_MajorId",
                table: "EducationProgram");

            migrationBuilder.DropIndex(
                name: "IX_BlockOfKnowledge_Course_CohortId_MajorId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "EducationProgram",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CohortId",
                table: "EducationProgram",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EducationProgram_CohortId_MajorId",
                table: "EducationProgram",
                columns: new[] { "CohortId", "MajorId" },
                unique: true,
                filter: "[CohortId] IS NOT NULL AND [MajorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationProgram_Cohort_Major_CohortId_MajorId",
                table: "EducationProgram",
                columns: new[] { "CohortId", "MajorId" },
                principalTable: "Cohort_Major",
                principalColumns: new[] { "CohortId", "MajorId" });
        }
    }
}

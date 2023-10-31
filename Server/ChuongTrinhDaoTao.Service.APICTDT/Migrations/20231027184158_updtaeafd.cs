using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class updtaeafd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course",
                columns: new[] { "BlockOfKnowledgeId", "CourseId", "MajorId", "CohortId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course",
                columns: new[] { "BlockOfKnowledgeId", "CourseId" });
        }
    }
}

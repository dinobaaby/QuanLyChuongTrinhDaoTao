using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class updateDbFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entity_BlockOfKnowledge_BlockOfKnowledgeId",
                table: "entity");

            migrationBuilder.DropForeignKey(
                name: "FK_entity_Course_CourseId",
                table: "entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entity",
                table: "entity");

            migrationBuilder.RenameTable(
                name: "entity",
                newName: "BlockOfKnowledge_Course");

            migrationBuilder.RenameIndex(
                name: "IX_entity_CourseId",
                table: "BlockOfKnowledge_Course",
                newName: "IX_BlockOfKnowledge_Course_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course",
                columns: new[] { "BlockOfKnowledgeId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlockOfKnowledge_Course_BlockOfKnowledge_BlockOfKnowledgeId",
                table: "BlockOfKnowledge_Course",
                column: "BlockOfKnowledgeId",
                principalTable: "BlockOfKnowledge",
                principalColumn: "BlockOfKnowledgeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockOfKnowledge_Course_Course_CourseId",
                table: "BlockOfKnowledge_Course",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockOfKnowledge_Course_BlockOfKnowledge_BlockOfKnowledgeId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockOfKnowledge_Course_Course_CourseId",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockOfKnowledge_Course",
                table: "BlockOfKnowledge_Course");

            migrationBuilder.RenameTable(
                name: "BlockOfKnowledge_Course",
                newName: "entity");

            migrationBuilder.RenameIndex(
                name: "IX_BlockOfKnowledge_Course_CourseId",
                table: "entity",
                newName: "IX_entity_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entity",
                table: "entity",
                columns: new[] { "BlockOfKnowledgeId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_entity_BlockOfKnowledge_BlockOfKnowledgeId",
                table: "entity",
                column: "BlockOfKnowledgeId",
                principalTable: "BlockOfKnowledge",
                principalColumn: "BlockOfKnowledgeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entity_Course_CourseId",
                table: "entity",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

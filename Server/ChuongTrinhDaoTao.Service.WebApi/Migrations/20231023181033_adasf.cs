using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class adasf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cohort_CohortId",
                table: "Users");

            

            migrationBuilder.AlterColumn<string>(
                name: "CohortId",
                table: "Users",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cohort_CohortId",
                table: "Users",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "CohortId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cohort_CohortId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "CohortId",
                table: "Users",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
 

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cohort_CohortId",
                table: "Users",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "CohortId");
        }
    }
}

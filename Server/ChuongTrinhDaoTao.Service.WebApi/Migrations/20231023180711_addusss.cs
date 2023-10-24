using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addusss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            migrationBuilder.AddColumn<string>(
                name: "CohortId",
                table: "Users",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cohort",
                columns: table => new
                {
                    CohortId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CohortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CohortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohort", x => x.CohortId);
                    table.ForeignKey(
                        name: "FK_Cohort_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CohortId",
                table: "Users",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_Cohort_MajorId",
                table: "Cohort",
                column: "MajorId");

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

            migrationBuilder.DropTable(
                name: "Cohort");

            migrationBuilder.DropIndex(
                name: "IX_Users_CohortId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "Users");

           

           

            
        }
    }
}

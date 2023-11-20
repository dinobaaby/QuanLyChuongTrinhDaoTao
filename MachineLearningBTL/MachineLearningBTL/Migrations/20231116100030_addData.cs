using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineLearningBTL.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_diaBetes",
                table: "diaBetes");

            migrationBuilder.RenameTable(
                name: "diaBetes",
                newName: "DiaBetes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaBetes",
                table: "DiaBetes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaBetes",
                table: "DiaBetes");

            migrationBuilder.RenameTable(
                name: "DiaBetes",
                newName: "diaBetes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_diaBetes",
                table: "diaBetes",
                column: "Id");
        }
    }
}

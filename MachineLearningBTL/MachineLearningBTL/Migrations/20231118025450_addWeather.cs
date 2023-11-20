using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineLearningBTL.Migrations
{
    /// <inheritdoc />
    public partial class addWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoAm = table.Column<float>(type: "real", nullable: false),
                    NhietDo = table.Column<float>(type: "real", nullable: false),
                    DoOn = table.Column<float>(type: "real", nullable: false),
                    AnhSang = table.Column<float>(type: "real", nullable: false),
                    KhiGas = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weathers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weathers");
        }
    }
}

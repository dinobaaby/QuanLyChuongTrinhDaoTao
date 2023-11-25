using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuongTrinhDaoTao.Service.APICTDT.Migrations
{
    /// <inheritdoc />
    public partial class addTuition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TuitionType",
                columns: table => new
                {
                    TuitionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionTypename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionType", x => x.TuitionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tuition",
                columns: table => new
                {
                    TuitionTypeId = table.Column<int>(type: "int", nullable: false),
                    TuitionId = table.Column<int>(type: "int", nullable: false),
                    TuitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuition", x => x.TuitionTypeId);
                    table.ForeignKey(
                        name: "FK_Tuition_TuitionType_TuitionTypeId",
                        column: x => x.TuitionTypeId,
                        principalTable: "TuitionType",
                        principalColumn: "TuitionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tuition");

            migrationBuilder.DropTable(
                name: "TuitionType");
        }
    }
}

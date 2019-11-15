using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMl.Migrations
{
    public partial class dedf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "PointData",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Label",
                table: "PointData",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

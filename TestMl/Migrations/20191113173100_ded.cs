using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMl.Migrations
{
    public partial class ded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Label",
                table: "PointData",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "x_pos",
                table: "PointData",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "y_pos",
                table: "PointData",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "PointData");

            migrationBuilder.DropColumn(
                name: "x_pos",
                table: "PointData");

            migrationBuilder.DropColumn(
                name: "y_pos",
                table: "PointData");
        }
    }
}

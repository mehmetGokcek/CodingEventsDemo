using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEventsDemo.Migrations
{
    public partial class AddLatAndLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

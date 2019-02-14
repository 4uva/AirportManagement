using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Data.Migrations
{
    public partial class AddedAirportName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Airports",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -7,
                column: "Name",
                value: "Buchara");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -6,
                column: "Name",
                value: "Henri Coandă");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -5,
                column: "Name",
                value: "Ferenc Liszt");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -4,
                column: "Name",
                value: "Kranebitten");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -3,
                column: "Name",
                value: "Gatwick");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -2,
                column: "Name",
                value: "Kazan");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "Amerigo Vespuchi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Airports");
        }
    }
}

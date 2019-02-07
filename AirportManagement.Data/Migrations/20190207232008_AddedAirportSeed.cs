using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Data.Migrations
{
    public partial class AddedAirportSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Location_LocationId",
                table: "Airports");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Airports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "LocalTimeZoneName", "Name" },
                values: new object[,]
                {
                    { -1, null, "Florence" },
                    { -2, null, "Elabuga" },
                    { -3, null, "Gatwick" },
                    { -4, null, "Innsbruk" },
                    { -5, null, "Budapest" },
                    { -6, null, "Bucharest" },
                    { -7, null, "Buchara" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "LocationId", "WeatherId" },
                values: new object[,]
                {
                    { -1, -1, null },
                    { -2, -2, null },
                    { -3, -3, null },
                    { -4, -4, null },
                    { -5, -5, null },
                    { -6, -6, null },
                    { -7, -7, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Location_LocationId",
                table: "Airports",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Location_LocationId",
                table: "Airports");

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Airports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Location_LocationId",
                table: "Airports",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

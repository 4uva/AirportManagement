using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LocalTimeZoneName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeatherId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Airports_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Airports_LocationId",
                table: "Airports",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_WeatherId",
                table: "Airports",
                column: "WeatherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WilliamsVacationPlanner.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_Vacations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vacations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationActivites",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationActivites", x => new { x.VacationId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_VacationActivites_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationActivites_Vacations_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacations",
                        principalColumn: "VacationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "AccommodationId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "holidayinn@gmail.com", "Holiday Inn Express", "770-123-4567" },
                    { 2, "hogwarts@gmail.com", "Hogwarts", "523-324-2342" },
                    { 3, "bill@gmail.com", "Bill's House", "451-532-5678" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 1, "Hiking" },
                    { 2, "Bowling" },
                    { 3, "Gambling" },
                    { 4, "Drinking" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Disney Land" },
                    { 2, "Lego Land" }
                });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "VacationId", "AccommodationId", "EndDate", "LocationId", "StartDate" },
                values: new object[] { 1, 2, new DateTime(2021, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "VacationId", "AccommodationId", "EndDate", "LocationId", "StartDate" },
                values: new object[] { 2, 3, new DateTime(2021, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), 2, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "VacationActivites",
                columns: new[] { "ActivityId", "VacationId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationActivites_ActivityId",
                table: "VacationActivites",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_AccommodationId",
                table: "Vacations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_LocationId",
                table: "Vacations",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationActivites");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}

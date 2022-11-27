using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VehicleModelCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 27, 11, 6, 51, 700, DateTimeKind.Local).AddTicks(9519))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehicleModel = table.Column<int>(type: "int", nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VehicleYearManufacture = table.Column<int>(type: "int", nullable: false),
                    VehicleYearModel = table.Column<int>(type: "int", nullable: false),
                    VehicleCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 27, 11, 6, 51, 700, DateTimeKind.Local).AddTicks(8863)),
                    VehicleModelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelsId",
                        column: x => x.VehicleModelsId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "VehicleModelDescription" },
                values: new object[] { 1, "FH" });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "VehicleModelDescription" },
                values: new object[] { 2, "FM" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelsId",
                table: "Vehicle",
                column: "VehicleModelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleModel");
        }
    }
}

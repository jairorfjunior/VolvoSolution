using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
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
                    VehicleModelCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 26, 19, 15, 45, 183, DateTimeKind.Local).AddTicks(7622))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdVehicleModel = table.Column<int>(type: "int", nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VehicleCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 26, 19, 15, 45, 183, DateTimeKind.Local).AddTicks(7118))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_Id",
                        column: x => x.Id,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "VehicleModelDescription" },
                values: new object[] { 1, "FH" });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "VehicleModelDescription" },
                values: new object[] { 2, "FM" });
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

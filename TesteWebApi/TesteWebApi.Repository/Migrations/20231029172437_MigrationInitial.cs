using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteWebApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSpaceCar = table.Column<int>(type: "int", nullable: false),
                    TotalSpaceMotorcycle = table.Column<int>(type: "int", nullable: false),
                    TotalSpaceVan = table.Column<int>(type: "int", nullable: false),
                    QtdSpacesCar = table.Column<int>(type: "int", nullable: false),
                    QtdSpacesMotorcycle = table.Column<int>(type: "int", nullable: false),
                    QtdSpacesBig = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}

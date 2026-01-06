using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarWorkshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalPassports_Vehicles_VehicleId",
                table: "TechnicalPassports");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MaintenanceRecords");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "BMW", "F10", 2018 },
                    { 2, "BMW", "E30", 1987 },
                    { 3, "Mercedes", "W123", 1982 }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "Cost", "Description", "VehicleId" },
                values: new object[,]
                {
                    { 1, 100, "Wymiana oleju", 1 },
                    { 2, 300, "Wymiana Filtrów", 1 },
                    { 3, 50, "Zmiana opon", 2 },
                    { 4, 400, "Wymiana tarcz hamulcowych", 3 },
                    { 5, 200, "Wymiana klockow hamulcowych", 3 },
                    { 6, 1500, "Wymiana glowicy", 3 },
                    { 7, 300, "Wymiana panewek", 3 }
                });

            migrationBuilder.InsertData(
                table: "TechnicalPassports",
                columns: new[] { "Id", "OwnerName", "RegistrationNumber", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Jakub", "GD 9321", 1 },
                    { 2, "Marcin", "WA 1234", 2 },
                    { 3, "Jan", "KK 2244", 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalPassports_Vehicles_VehicleId",
                table: "TechnicalPassports",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalPassports_Vehicles_VehicleId",
                table: "TechnicalPassports");

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TechnicalPassports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechnicalPassports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechnicalPassports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MaintenanceRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalPassports_Vehicles_VehicleId",
                table: "TechnicalPassports",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

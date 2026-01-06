using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords",
                column: "VehicleId",
                unique: true);
        }
    }
}

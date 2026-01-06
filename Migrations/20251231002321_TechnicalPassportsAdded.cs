using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class TechnicalPassportsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnicalPassports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalPassports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalPassports");
        }
    }
}

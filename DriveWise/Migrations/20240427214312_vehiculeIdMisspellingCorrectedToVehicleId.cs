using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveWise.Migrations
{
    /// <inheritdoc />
    public partial class vehiculeIdMisspellingCorrectedToVehicleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehiculeId",
                table: "Rentals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiculeId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

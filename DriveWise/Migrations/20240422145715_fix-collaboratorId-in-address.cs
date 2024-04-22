using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveWise.Migrations
{
    /// <inheritdoc />
    public partial class fixcollaboratorIdinaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborators_Addresses_AddressId",
                table: "Collaborators");

            migrationBuilder.DropIndex(
                name: "IX_Collaborators_AddressId",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Collaborators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Collaborators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_AddressId",
                table: "Collaborators",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborators_Addresses_AddressId",
                table: "Collaborators",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}

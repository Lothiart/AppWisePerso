using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveWise.Migrations
{
    /// <inheritdoc />
    public partial class deleted_collab_prop_from_Vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Collaborators_CollaboratorId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "CollaboratorId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Collaborators_CollaboratorId",
                table: "Vehicles",
                column: "CollaboratorId",
                principalTable: "Collaborators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Collaborators_CollaboratorId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "CollaboratorId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Collaborators_CollaboratorId",
                table: "Vehicles",
                column: "CollaboratorId",
                principalTable: "Collaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

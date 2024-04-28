using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveWise.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Motor_MotorId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Models_Name",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motor",
                table: "Motor");

            migrationBuilder.RenameTable(
                name: "Motor",
                newName: "Motors");

            migrationBuilder.RenameIndex(
                name: "IX_Motor_Type",
                table: "Motors",
                newName: "IX_Motors_Type");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motors",
                table: "Motors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Motors_MotorId",
                table: "Vehicles",
                column: "MotorId",
                principalTable: "Motors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Motors_MotorId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motors",
                table: "Motors");

            migrationBuilder.RenameTable(
                name: "Motors",
                newName: "Motor");

            migrationBuilder.RenameIndex(
                name: "IX_Motors_Type",
                table: "Motor",
                newName: "IX_Motor_Type");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motor",
                table: "Motor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Motor_MotorId",
                table: "Vehicles",
                column: "MotorId",
                principalTable: "Motor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Lastmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillOfLadings_Drivers_DriverId",
                table: "BillOfLadings");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "BillOfLadings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfLadings_Drivers_DriverId",
                table: "BillOfLadings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillOfLadings_Drivers_DriverId",
                table: "BillOfLadings");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "BillOfLadings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfLadings_Drivers_DriverId",
                table: "BillOfLadings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

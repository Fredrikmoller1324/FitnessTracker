using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class relationshipchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines");

            migrationBuilder.DropIndex(
                name: "IX_Routines_UserId",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Routines");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRoutines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutines_UserId",
                table: "UserRoutines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Users_UserId",
                table: "UserRoutines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Users_UserId",
                table: "UserRoutines");

            migrationBuilder.DropIndex(
                name: "IX_UserRoutines_UserId",
                table: "UserRoutines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoutines");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Routines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routines_UserId",
                table: "Routines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

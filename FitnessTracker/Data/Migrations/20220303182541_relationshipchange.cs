using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class relationshipchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routines_UserRoutines_UserRoutineId",
                table: "Routines");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoutines_UserRoutineId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoutineId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoutineId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "test",
                table: "UserRoutines");

            migrationBuilder.RenameColumn(
                name: "UserRoutineId",
                table: "Routines",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_UserRoutineId",
                table: "Routines",
                newName: "IX_Routines_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RoutineId",
                table: "UserRoutines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutines_RoutineId",
                table: "UserRoutines",
                column: "RoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Routines_RoutineId",
                table: "UserRoutines",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Routines_RoutineId",
                table: "UserRoutines");

            migrationBuilder.DropIndex(
                name: "IX_UserRoutines_RoutineId",
                table: "UserRoutines");

            migrationBuilder.DropColumn(
                name: "RoutineId",
                table: "UserRoutines");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Routines",
                newName: "UserRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_UserId",
                table: "Routines",
                newName: "IX_Routines_UserRoutineId");

            migrationBuilder.AddColumn<int>(
                name: "UserRoutineId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "UserRoutines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoutineId",
                table: "Users",
                column: "UserRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_UserRoutines_UserRoutineId",
                table: "Routines",
                column: "UserRoutineId",
                principalTable: "UserRoutines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoutines_UserRoutineId",
                table: "Users",
                column: "UserRoutineId",
                principalTable: "UserRoutines",
                principalColumn: "Id");
        }
    }
}

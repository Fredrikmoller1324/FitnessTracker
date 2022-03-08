using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class changetablenamntouserworkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Exercises_ExerciseId",
                table: "UserRoutines");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Users_UserId",
                table: "UserRoutines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoutines",
                table: "UserRoutines");

            migrationBuilder.RenameTable(
                name: "UserRoutines",
                newName: "UserWorkouts");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutines_UserId",
                table: "UserWorkouts",
                newName: "IX_UserWorkouts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutines_ExerciseId",
                table: "UserWorkouts",
                newName: "IX_UserWorkouts_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Exercises_ExerciseId",
                table: "UserWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Users_UserId",
                table: "UserWorkouts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Exercises_ExerciseId",
                table: "UserWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Users_UserId",
                table: "UserWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts");

            migrationBuilder.RenameTable(
                name: "UserWorkouts",
                newName: "UserRoutines");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkouts_UserId",
                table: "UserRoutines",
                newName: "IX_UserRoutines_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkouts_ExerciseId",
                table: "UserRoutines",
                newName: "IX_UserRoutines_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoutines",
                table: "UserRoutines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Exercises_ExerciseId",
                table: "UserRoutines",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Users_UserId",
                table: "UserRoutines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

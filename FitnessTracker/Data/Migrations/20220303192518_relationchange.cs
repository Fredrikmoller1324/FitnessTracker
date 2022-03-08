using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class relationchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercises_Exercises_ExerciseId",
                table: "UserRoutineExercises");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "UserRoutineExercises",
                newName: "RoutineExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercises_ExerciseId",
                table: "UserRoutineExercises",
                newName: "IX_UserRoutineExercises_RoutineExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercises_RoutineExercises_RoutineExerciseId",
                table: "UserRoutineExercises",
                column: "RoutineExerciseId",
                principalTable: "RoutineExercises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercises_RoutineExercises_RoutineExerciseId",
                table: "UserRoutineExercises");

            migrationBuilder.RenameColumn(
                name: "RoutineExerciseId",
                table: "UserRoutineExercises",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercises_RoutineExerciseId",
                table: "UserRoutineExercises",
                newName: "IX_UserRoutineExercises_ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercises_Exercises_ExerciseId",
                table: "UserRoutineExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}

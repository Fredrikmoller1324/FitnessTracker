using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class userroutineexerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercise_Exercises_ExerciseId",
                table: "UserRoutineExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercise_UserRoutines_UserRoutineId",
                table: "UserRoutineExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoutineExercise",
                table: "UserRoutineExercise");

            migrationBuilder.RenameTable(
                name: "UserRoutineExercise",
                newName: "UserRoutineExercises");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercise_UserRoutineId",
                table: "UserRoutineExercises",
                newName: "IX_UserRoutineExercises_UserRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercise_ExerciseId",
                table: "UserRoutineExercises",
                newName: "IX_UserRoutineExercises_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoutineExercises",
                table: "UserRoutineExercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercises_Exercises_ExerciseId",
                table: "UserRoutineExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercises_UserRoutines_UserRoutineId",
                table: "UserRoutineExercises",
                column: "UserRoutineId",
                principalTable: "UserRoutines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercises_Exercises_ExerciseId",
                table: "UserRoutineExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutineExercises_UserRoutines_UserRoutineId",
                table: "UserRoutineExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoutineExercises",
                table: "UserRoutineExercises");

            migrationBuilder.RenameTable(
                name: "UserRoutineExercises",
                newName: "UserRoutineExercise");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercises_UserRoutineId",
                table: "UserRoutineExercise",
                newName: "IX_UserRoutineExercise_UserRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutineExercises_ExerciseId",
                table: "UserRoutineExercise",
                newName: "IX_UserRoutineExercise_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoutineExercise",
                table: "UserRoutineExercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercise_Exercises_ExerciseId",
                table: "UserRoutineExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutineExercise_UserRoutines_UserRoutineId",
                table: "UserRoutineExercise",
                column: "UserRoutineId",
                principalTable: "UserRoutines",
                principalColumn: "Id");
        }
    }
}

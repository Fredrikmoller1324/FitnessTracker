using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class userroutineexercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoutineExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reps = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    UserRoutineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoutineExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoutineExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoutineExercise_UserRoutines_UserRoutineId",
                        column: x => x.UserRoutineId,
                        principalTable: "UserRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutineExercise_ExerciseId",
                table: "UserRoutineExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutineExercise_UserRoutineId",
                table: "UserRoutineExercise",
                column: "UserRoutineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoutineExercise");
        }
    }
}

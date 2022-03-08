using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class junctiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Exercises_ExerciseId",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_ExerciseId",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "UserWorkouts");

            migrationBuilder.CreateTable(
                name: "ExerciseUserWorkout",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    UserWorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseUserWorkout", x => new { x.ExercisesId, x.UserWorkoutsId });
                    table.ForeignKey(
                        name: "FK_ExerciseUserWorkout_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseUserWorkout_UserWorkouts_UserWorkoutsId",
                        column: x => x.UserWorkoutsId,
                        principalTable: "UserWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseUserWorkout_UserWorkoutsId",
                table: "ExerciseUserWorkout",
                column: "UserWorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseUserWorkout");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "UserWorkouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_ExerciseId",
                table: "UserWorkouts",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Exercises_ExerciseId",
                table: "UserWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}

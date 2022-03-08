using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class changedbstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategories_ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Routines_RoutineId",
                table: "UserRoutines");

            migrationBuilder.DropTable(
                name: "UserRoutineExercises");

            migrationBuilder.DropTable(
                name: "RoutineExercises");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "RoutineId",
                table: "UserRoutines",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutines_RoutineId",
                table: "UserRoutines",
                newName: "IX_UserRoutines_ExerciseId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserRoutines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseExerciseCategory",
                columns: table => new
                {
                    ExerciseCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExerciseCategory", x => new { x.ExerciseCategoriesId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategory_ExerciseCategories_ExerciseCategoriesId",
                        column: x => x.ExerciseCategoriesId,
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategory_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseCategory_ExercisesId",
                table: "ExerciseExerciseCategory",
                column: "ExercisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Exercises_ExerciseId",
                table: "UserRoutines",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutines_Exercises_ExerciseId",
                table: "UserRoutines");

            migrationBuilder.DropTable(
                name: "ExerciseExerciseCategory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserRoutines");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "UserRoutines",
                newName: "RoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoutines_ExerciseId",
                table: "UserRoutines",
                newName: "IX_UserRoutines_RoutineId");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    RoutineId = table.Column<int>(type: "int", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoutineExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutineExerciseId = table.Column<int>(type: "int", nullable: true),
                    UserRoutineId = table.Column<int>(type: "int", nullable: true),
                    reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoutineExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoutineExercises_RoutineExercises_RoutineExerciseId",
                        column: x => x.RoutineExerciseId,
                        principalTable: "RoutineExercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoutineExercises_UserRoutines_UserRoutineId",
                        column: x => x.UserRoutineId,
                        principalTable: "UserRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseCategoryId",
                table: "Exercises",
                column: "ExerciseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_ExerciseId",
                table: "RoutineExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_RoutineId",
                table: "RoutineExercises",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutineExercises_RoutineExerciseId",
                table: "UserRoutineExercises",
                column: "RoutineExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoutineExercises_UserRoutineId",
                table: "UserRoutineExercises",
                column: "UserRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategories_ExerciseCategoryId",
                table: "Exercises",
                column: "ExerciseCategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutines_Routines_RoutineId",
                table: "UserRoutines",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "Id");
        }
    }
}

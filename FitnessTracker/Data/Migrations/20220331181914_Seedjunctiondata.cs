using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class Seedjunctiondata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseExerciseCategory");

            migrationBuilder.CreateTable(
                name: "ExerciseExerciseCategories",
                columns: table => new
                {
                    ExerciseCategoryId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExerciseCategories", x => new { x.ExerciseCategoryId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategories_ExerciseCategories_ExerciseCategoryId",
                        column: x => x.ExerciseCategoryId,
                        principalTable: "ExerciseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseCategories_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseExerciseCategories",
                columns: new[] { "ExerciseCategoryId", "ExerciseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 6, 1 },
                    { 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseCategories_ExerciseId",
                table: "ExerciseExerciseCategories",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseExerciseCategories");

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
        }
    }
}

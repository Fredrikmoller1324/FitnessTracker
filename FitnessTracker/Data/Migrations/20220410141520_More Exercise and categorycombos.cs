using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    public partial class MoreExerciseandcategorycombos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Shoulders" });

            migrationBuilder.InsertData(
                table: "ExerciseExerciseCategories",
                columns: new[] { "ExerciseCategoryId", "ExerciseId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 5 },
                    { 7, 2 },
                    { 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "OverHead Press" });

            migrationBuilder.InsertData(
                table: "ExerciseExerciseCategories",
                columns: new[] { "ExerciseCategoryId", "ExerciseId" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "ExerciseExerciseCategories",
                columns: new[] { "ExerciseCategoryId", "ExerciseId" },
                values: new object[] { 8, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseExerciseCategories",
                keyColumns: new[] { "ExerciseCategoryId", "ExerciseId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

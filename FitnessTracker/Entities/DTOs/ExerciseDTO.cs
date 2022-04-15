namespace FitnessTracker.Entities.DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExerciseCategory> ExerciseCategories { get; set; }
    }
}

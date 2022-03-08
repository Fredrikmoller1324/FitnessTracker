namespace FitnessTracker.Entities
{
    public class ExerciseCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}

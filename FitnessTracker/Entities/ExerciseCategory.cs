using FitnessTracker.Interfaces;
using System.Text.Json.Serialization;

namespace FitnessTracker.Entities
{
    public class ExerciseCategory : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Exercise> Exercises { get; set; }
    }
}

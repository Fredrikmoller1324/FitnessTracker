using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessTracker.Entities
{
    public class ExerciseCategory : BaseEntity
    {
        [Key]
        public new int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Exercise> Exercises { get; set; }
    }
}

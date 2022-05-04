using FitnessTracker.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public List<UserWorkout> UserWorkouts { get; set; } = new List<UserWorkout>();


    }
}

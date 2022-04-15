using FitnessTracker.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Data.EntityConfigurations
{
    public class ExerciseEntityTypeConfigurations
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new Exercise
                     {
                        Id = 1,
                        Name = "Squat"
                    },
                    new Exercise
                    {
                        Id = 2,
                        Name = "Deadlift"
                    },
                    new Exercise
                    {
                        Id = 3,
                        Name = "Bench press"
                    },
                    new Exercise
                    {
                        Id = 4,
                        Name = "Bicep Curl"
                    },
                    new Exercise
                    {
                        Id = 5,
                        Name = "Leg press"
                    },
                    new Exercise
                    {
                        Id = 6,
                        Name = "OverHead Press"
                    });
        }
    }
}

using FitnessTracker.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Data.EntityConfigurations
{
    public class ExerciseCategoryEntityTypeConfigurations
    {

        public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new ExerciseCategory
                     { 
                        Id = 1,
                        Name = "Upper Back"
                     },
                     new ExerciseCategory 
                     {
                         Id = 2,
                         Name = "Lower Back"
                     },
                     new ExerciseCategory 
                     { 
                         Id = 3,
                         Name = "Chest"
                     },
                     new ExerciseCategory 
                     { 
                         Id = 4,
                         Name = "Biceps"
                     },
                     new ExerciseCategory
                     {
                         Id = 5,
                         Name = "Triceps"
                     },
                     new ExerciseCategory 
                     { 
                         Id = 6,
                         Name = "Legs" 
                     },
                     new ExerciseCategory 
                     { 
                         Id = 7,
                         Name = "Calves" 
                     });
        }
    }
}

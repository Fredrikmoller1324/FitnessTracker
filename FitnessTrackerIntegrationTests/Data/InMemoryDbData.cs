using FitnessTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerIntegrationTests.Data
{
    public static class InMemoryDbData
    {
        public static List<Exercise> GetExercisesData()
        {
            var exercices = new List<Exercise>()
            {
                new Exercise
                {
                    Id = 1,
                    Name = "SquatONE"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "DeadliftTWO"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Bench pressTHREE"
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Bicep CurlFOUR"
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Leg pressFIVE"
                },
                new Exercise
                {
                    Id = 6,
                    Name = "OverHead PressSIX"
                }
            };

            return exercices;
        }

        public static List<ExerciseCategory> GetExerciseCategories()
        {
            List<ExerciseCategory> exercisecategories = new List<ExerciseCategory>()
            {
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
                     },
                    new ExerciseCategory
                    {
                        Id = 8,
                        Name = "Shoulders"
                    }
            };

            return exercisecategories;

        }
    }
}

using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerUnitTests
{
    public static class MoqData
    {
        public static List<ExerciseDTO> GetExerciseDTOs()
        {
            return new List<ExerciseDTO>()
            {
                new ExerciseDTO()
                {
                    Id = 1,
                    Name = "exercise1TEST",
                    ExerciseCategories = new List<ExerciseCategory>
                    {
                        new ExerciseCategory()
                        {
                            Name = "Arms",
                            Id = 1
                        }
                    }
                },
                 new ExerciseDTO()
                {
                    Id = 2,
                    Name = "exercise2TEST",
                    ExerciseCategories = new List<ExerciseCategory>
                    {
                        new ExerciseCategory()
                        {
                            Name = "legs",
                            Id = 2
                        }
                    }
                }
            };
        }
    }
}

using FitnessTracker.Controllers;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FitnessTrackerTests.ControllersTests
{
    
    public class ExerciseControllerTests
    {
        private readonly Mock<IExerciseService> _mockRepo;
        private readonly ExerciseController _controller;
        public ExerciseControllerTests()
        {
            _mockRepo = new Mock<IExerciseService>();
            _controller = new ExerciseController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllExercices_ActionExecutes_ReturnsAllExercices()
        {
            List<ExerciseDTO> exercies = new List<ExerciseDTO>()
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

            _mockRepo.Setup(repo => repo.GetAllExercisesAsync())
                .ReturnsAsync(exercies);

            var result = await _controller.GetAllExercises() as ObjectResult;

            var actualResult = result.Value;

            Assert.NotNull(actualResult);
            Assert.IsType<OkObjectResult>(result);
            
            Assert.Equal(exercies.Count,((List<ExerciseDTO>)actualResult).Count);
        }

        [Fact]
        public void test()
        {
            Assert.True(true);
        }
    }
}

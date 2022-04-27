using FitnessTracker.Controllers;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FitnessTrackerUnitTests
{
    public class ExerciseControllerTests
    {
        private readonly Mock<IExerciseService> _mockRepo;
        private readonly Mock<ILogger<ExerciseController>> _mockLogger;
        private readonly ExerciseController _controller;
        public ExerciseControllerTests()
        {
            _mockRepo = new Mock<IExerciseService>();
            _mockLogger = new Mock<ILogger<ExerciseController>>();
            _controller = new ExerciseController(_mockRepo.Object, (ILogger<ExerciseController>)_mockLogger);
        }

        [Fact]
        public async Task GetAllExercices_ActionExecutes_ReturnsAllExercices()
        {
            var exercices = MoqData.GetExerciseDTOs();

            _mockRepo.Setup(repo => repo.GetAllExercisesAsync())
                .ReturnsAsync(exercices);

            var result = await _controller.GetAllExercises() as OkObjectResult;

            var actualResult = result?.Value as List<ExerciseDTO>;

            Assert.NotNull(actualResult);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(exercices, actualResult);
            Assert.Equal(exercices.Count, actualResult?.Count);
        }

        [Fact]
        public async Task GetExerciseByName_ActionExecutes_ReturnsCorrectExercicse()
        {
            var exercices = MoqData.GetExerciseDTOs();

            _mockRepo.Setup(repo => repo.GetByNameAsync("exercise1test"))
                .ReturnsAsync(exercices[0]);


            var result = await _controller.GetExercise("exercise1test") as OkObjectResult;

            var actualResult = result?.Value as ExerciseDTO;

            Assert.NotNull(actualResult);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(exercices[0], actualResult);
            Assert.Equal(exercices[0].Name, actualResult?.Name);
            Assert.Equal(exercices[0].Id, actualResult?.Id);

        }

        [Theory]
        [InlineData("NOTEXIST")]
        public async Task GetExerciseByName_ActionExecutes_ReturnInternalServerError(string input)
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByNameAsync($"{input}")).ThrowsAsync(new KeyNotFoundException($"Exercise with name '{input}' does not exist"));

            // Act
            var result = await _controller.GetExercise($"{input}") as ObjectResult;
            var actualtResult = result.Value;

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, (HttpStatusCode)result.StatusCode);
            Assert.Equal($"Exercise with name '{input}' does not exist", result.Value);
        }

        [Fact]
        public async Task CreateExercise_ActionExecutes_ReturnsOk()
        {
            var exerciseToCreate = new ExerciseDTO()
            {
                Name = "exerciseTest",
                Id = 1,
                ExerciseCategories = new List<ExerciseCategory>
                { new ExerciseCategory()
                    {
                        Id = 1,
                        Name ="Arms"
                    }
                }
            };

            var createdExercise = new Exercise()
            {
                Name = "exerciseTest",
                Id = 1,
                ExerciseCategories = new List<ExerciseCategory>
                { new ExerciseCategory()
                    {
                        Id = 1,
                        Name ="Arms"
                    }
                }
            };

            _mockRepo.Setup(repo => repo.CreateExerciseAsync(exerciseToCreate))
                .ReturnsAsync(createdExercise);

            var result = await _controller.CreateExercise(exerciseToCreate) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(createdExercise, result?.Value);
            Assert.Equal(createdExercise.Name, (result?.Value as Exercise)?.Name);
            Assert.Equal(createdExercise.Id, (result?.Value as Exercise)?.Id);
            Assert.Equal(createdExercise.ExerciseCategories, (result?.Value as Exercise)?.ExerciseCategories);
        }
        [Fact]
        public async Task DeleteExercise_ActionExecutes_ReturnsOk()
        {
            int id = 1;

            var deletedExercise = new Exercise()
            {
                Name = "exerciseTest",
                Id = 1,
                ExerciseCategories = new List<ExerciseCategory>
                { new ExerciseCategory()
                    {
                        Id = 1,
                        Name ="Arms"
                    }
                }
            };

            _mockRepo.Setup(repo => repo.DeleteExerciseAsync(id))
                .ReturnsAsync(deletedExercise);

            var result = await _controller.DeleteExercise(id) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(deletedExercise, result?.Value);
            Assert.Equal(deletedExercise.Name, (result?.Value as Exercise)?.Name);
            Assert.Equal(deletedExercise.Id, (result?.Value as Exercise)?.Id);
            Assert.Equal(deletedExercise.ExerciseCategories, (result?.Value as Exercise)?.ExerciseCategories);
        }
    }
}
using FitnessTracker.Data;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FitnessTrackerIntegrationTests.Controllers
{
    public class ExerciseControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetExercises_RunAction_ReturnsAllexercices()
        {
            var response = await _client.GetAsync("https://localhost:7146/api/Exercise/GetAllExercises");

            var responseData = await response.Content.ReadAsStringAsync();
            var dataAsObject = JsonConvert.DeserializeObject<List<ExerciseDTO>>(responseData);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(dataAsObject);
            Assert.Equal(6, dataAsObject.Count);
            Assert.IsType<List<ExerciseDTO>>(dataAsObject);
        }

        [Fact]
        public async Task CreateExercise_RunAction_SuccesfullyCreatesExercise()
        {
            var createdExercise = await CreateExercicseAsync(
        new ExerciseDTO
                {
                    Name = "createdExercise3",
                    ExerciseCategories = new List<ExerciseCategory>()
                    {
                        new ExerciseCategory()
                        {
                            Name = "test",
                        }
                    }
                });

            Assert.IsType<Exercise>(createdExercise);
            Assert.Equal("createdExercise3", createdExercise.Name);
            Assert.Equal(7, createdExercise.Id);

        }


    }
}
